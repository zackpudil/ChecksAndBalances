using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecksAndBalances.Data.Storage.Context
{
    public class ChecksAndBalancesInitializer : DropCreateDatabaseIfModelChanges<ChecksAndBalancesContext> { }
}
