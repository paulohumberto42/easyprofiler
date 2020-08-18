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
            IServiceCollection services = new ServiceCollection();

            services.AddEasyProfiler();
            services.AddEasyProfiler();
            services.AddEasyProfiler();

            services.EasyProfiled()
                .AddTransient<IRepository, Repository>()
                .AddTransient<IService, Service>();

            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IService>();

            MiniProfiler.StartNew();

            service.DoWork();

            Console.WriteLine(MiniProfiler.Current.RenderPlainText());
        }
    }
}
