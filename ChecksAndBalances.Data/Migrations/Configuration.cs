namespace ChecksAndBalances.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChecksAndBalances.Data.Storage.Context.ChecksAndBalancesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ChecksAndBalances.Data.Storage.Context.ChecksAndBalancesContext context)
        {
        }
    }
}
