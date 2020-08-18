using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EasyProfiler.Demo.Services;

namespace EasyProfiler.Demo.Implementations
{
    public class Repository : IRepository
    {
        public void QueryA()
        {
            Thread.Sleep(500);
        }

        public void QueryB()
        {
            Thread.Sleep(300);
        }

        public void QueryC()
        {
            Thread.Sleep(100);
        }
    }
}
