using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Models;

namespace ChecksAndBalances.Data.Storage.Context
{
    public class ChecksAndBalancesContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}
