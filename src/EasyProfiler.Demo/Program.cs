using System;
using System.Security.Cryptography;
using EasyProfiler.Demo.Implementations;
using EasyProfiler.Demo.Services;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Profiling;

namespace EasyProfiler.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingServiceCollection();
            SimpleUsage();
        }
        
        static void UsingServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddEasyProfiler();

            services.EasyProfiled()
                .AddTransient<IRepository, Repository>()
                .AddTransient<IService, Service>();

            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IService>();

            MiniProfiler.StartNew(nameof(UsingServiceCollection));
            service.DoWork();
            Console.WriteLine(MiniProfiler.Current.RenderPlainText());
        }

        static void SimpleUsage()
        {
            var proxyFactory = new ProfilingProxyFactory();
            
            IRepository repository = new Repository();
            IRepository repositoryProxy = proxyFactory.CreateProxy(repository);

            IService service = new Service(repositoryProxy);
            IService serviceProxy = proxyFactory.CreateProxy(service);

            MiniProfiler.StartNew(nameof(SimpleUsage));
            serviceProxy.DoWork();
            Console.WriteLine(MiniProfiler.Current.RenderPlainText());

        }
    }
}
