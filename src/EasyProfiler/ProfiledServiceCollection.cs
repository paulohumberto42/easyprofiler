using System;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler
{
    public class ProfiledServiceCollection
    {
        private readonly IServiceCollection innerServiceCollection;

        internal ProfiledServiceCollection(IServiceCollection serviceCollection)
        {
            this.innerServiceCollection = serviceCollection;
        }

        public ProfiledServiceCollection AddTransient(Type serviceType, Type implementationType)
        {
            return this.Add(serviceType, implementationType, ServiceLifetime.Transient);
        }

        public ProfiledServiceCollection AddTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            return this.AddTransient(typeof(TService), typeof(TImplementation));
        }

        public ProfiledServiceCollection AddScoped(Type serviceType, Type implementationType)
        {
            return this.Add(serviceType, implementationType, ServiceLifetime.Scoped);
        }

        public ProfiledServiceCollection AddScoped<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            return this.AddScoped(typeof(TService), typeof(TImplementation));
        }


        public ProfiledServiceCollection AddSingleton(Type serviceType, Type implementationType)
        {
            return this.Add(serviceType, implementationType, ServiceLifetime.Singleton);
        }

        public ProfiledServiceCollection AddSingleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            return this.AddSingleton(typeof(TService), typeof(TImplementation));
        }

        private ProfiledServiceCollection Add(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            var proxyDescriptor = new ServiceDescriptor(
                serviceType,
                p => CreateProxiedInstance(p, serviceType, implementationType),
                lifetime);

            this.innerServiceCollection.Add(proxyDescriptor);
            this.innerServiceCollection.Add(new ServiceDescriptor(implementationType, implementationType, lifetime));
            return this;
        }

        private static object CreateProxiedInstance(IServiceProvider serviceProvider, Type serviceType, Type implementationType)
        {
            var factory = serviceProvider.GetRequiredService<ProfilingProxyFactory>();
            return factory.CreateProxy(serviceProvider.GetRequiredService(implementationType), serviceType);
        }
    }
}
