using System;
using Castle.DynamicProxy;

namespace EasyProfiler
{
    public class ProfilingProxyFactory
    {
        private readonly EasyProfilerOptions options;
        private readonly ProxyGenerator generator;

        public ProfilingProxyFactory(EasyProfilerOptions options)
        {
            this.options = options;
            this.generator = new ProxyGenerator();
        }

        public object CreateProxy(object target, Type serviceType)
        {
            return this.generator.CreateInterfaceProxyWithTarget(
                serviceType,
                target,
                new ProfilingInterceptor(this.options));
        }
    }
}
