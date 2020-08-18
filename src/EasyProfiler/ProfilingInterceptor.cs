using System.Diagnostics;
using Castle.DynamicProxy;
using StackExchange.Profiling;

namespace EasyProfiler
{
    internal class ProfilingInterceptor : IInterceptor
    {
        private readonly EasyProfilerOptions options;

        internal ProfilingInterceptor(EasyProfilerOptions options)
        {
            this.options = options;
        }

        [DebuggerStepThrough]
        public void Intercept(IInvocation invocation)
        {
            string stepName = options.FormatStep(invocation.TargetType, invocation.Method);

            using (MiniProfiler.Current.Step(stepName))
            {
                invocation.Proceed();
            }
        }
    }
}
