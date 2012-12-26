using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Models;

namespace ChecksAndBalances.Data.Storage.Context
{
    public class SimpleMembershipContext : DbContext    {
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
