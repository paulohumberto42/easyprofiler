using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler
{
    public static class EasyProfilerExtensions
    {
        public static IServiceCollection AddEasyProfiler(this IServiceCollection services, EasyProfilerOptions options = null)
        {
            if (options == null)
            {
                options = new EasyProfilerOptions();
            }

            services.AddSingleton(options);
            services.AddSingleton<ProfilingProxyFactory>();

            return services;
        }

        public static ProfiledServiceCollection EasyProfiled(this IServiceCollection services)
        {
            return new ProfiledServiceCollection(services);
        }
    }
}
