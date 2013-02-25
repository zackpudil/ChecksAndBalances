using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using ChecksAndBalances.Data.Models.Enum;
using WebMatrix.WebData;

namespace ChecksAndBalances.Data.Storage.Context.SimpleMembership
{
    public class SimpleMembershipInitializer
    {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<SimpleMembershipContext>(null);

                try
                {
                    using (var context = new SimpleMembershipContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("ChecksAndBalances", "UserProfiles", "Id", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }

                if (!Roles.RoleExists("Administrator"))
                    Roles.CreateRole("Administrator");

                if (!Roles.RoleExists("Buyer"))
                    Roles.CreateRole("Buyer");

                if (!Roles.RoleExists("Player"))
                    Roles.CreateRole("Player");

                if (!WebSecurity.UserExists("admin"))
                    WebSecurity.CreateUserAndAccount(
                        "admin",
                        "password4C&B",
                        new { Email = "checksandbalances.com@gmail.com", FirstName = "Shawn", LastName = "Towle", StateId = (int)State.DC });

                if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
                    Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
            }
    }
}
