using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Infrastructure;
using Ninject.Extensions.Conventions;

namespace ChecksAndBalances.Data.Infrastructure
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
                .BindAllInterfaces()
                .Configure(b => b.InTransientScope()));

            RegisterDatabaseInitializer();
        }

        public static void RegisterDatabaseInitializer()
        {
            //used for active development. Deletes database on every model change!
        }
    }
}
