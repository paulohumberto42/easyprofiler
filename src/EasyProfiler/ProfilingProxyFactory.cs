using System;
using Castle.DynamicProxy;

namespace EasyProfiler
{
    public class ProfilingProxyFactory
    {
        private readonly EasyProfilerOptions options;
        private readonly ProxyGenerator generator;

        public ProfilingProxyFactory(EasyProfilerOptions options = null)
        {
            this.options = options ?? new EasyProfilerOptions();
            this.generator = new ProxyGenerator();
        }

        public T CreateProxy<T>(T target)
        {
            return (T)this.CreateProxy(target, typeof(T));
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
