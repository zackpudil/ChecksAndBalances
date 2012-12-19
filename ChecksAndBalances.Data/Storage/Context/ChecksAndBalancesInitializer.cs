using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Migrations;

namespace ChecksAndBalances.Data.Storage.Context
{
    internal class ChecksAndBalancesInitializer : MigrateDatabaseToLatestVersion<ChecksAndBalancesContext, Configuration> { }
}
