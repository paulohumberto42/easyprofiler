using System;
using System.Reflection;

namespace EasyProfiler
{
    public class EasyProfilerOptions
    {
        public EasyProfilerOptions()
        {
            this.FormatStep = DefaultFormatStep;
        }

        public Func<Type, MethodInfo, string> FormatStep { get; set; }

        private static string DefaultFormatStep(Type targetType, MethodInfo method)
        {
            return $"{targetType.FullName}.{method.Name}";
        }
    }
}
