using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EasyProfiler.Demo.Services;

namespace EasyProfiler.Demo.Implementations
{
    public class Service : IService
    {
        private readonly IRepository repository;

        public Service(IRepository repository)
        {
            this.repository = repository;
        }

        public void DoWork()
        {
            this.repository.QueryA();
            this.repository.QueryB();
            this.repository.QueryC();
        }
    }
}
