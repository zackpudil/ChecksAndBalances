using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Extensions.Conventions;

namespace ChecksAndBalances.Service.Infrastructure
{
    public class AppStart
    {
        public static void RegisterAssemblies(IKernel kernel)
        {
            if (kernel == null)
                throw new ArgumentException("can not be null", "kernel");

            kernel.Bind(x => x
                .FromThisAssembly()
                .SelectAllClasses()
                .InNamespaces(new string[] { "ChecksAndBalances.Service.Mappers", "ChecksAndBalances.Service.Validators" })
                .BindAllInterfaces()
                .Configure(b => b.InSingletonScope()));

            kernel.Bind(x => x
                .FromThisAssembly()
                .SelectAllClasses()
                .InNamespaces(new string[] { "ChecksAndBalances.Service.Services" })
                .BindAllInterfaces()
                .Configure(b => b.InTransientScope()));
        }
    }
}
