using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler
{
    public static class EasyProfilerExtensions
    {
        public static IServiceCollection AddEasyProfiler(this IServiceCollection services, EasyProfilerOptions options = null)
        {
            services.AddSingleton(new ProfilingProxyFactory(options));

            return services;
        }

        public static ProfiledServiceCollection EasyProfiled(this IServiceCollection services)
        {
            return new ProfiledServiceCollection(services);
        }
    }
}
