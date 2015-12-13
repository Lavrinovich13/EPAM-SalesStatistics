using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SalesStatistics.Models
{
    public class UsersDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var adminRole = new IdentityRole { Name = "Admin" };
            var userRole = new IdentityRole { Name = "User" };

            roleManager.Create(adminRole);
            roleManager.Create(userRole);

            var admin = new ApplicationUser { Email = "admin@gmail.com", UserName = "admin@gmail.com" };
            string password = "123456";
            var result = userManager.Create(admin, password);

            var user = new ApplicationUser { Email = "user@gmail.com", UserName = "user@gmail.com" };
            var resultuser = userManager.Create(user, "123456");
            userManager.AddToRole(user.Id, userRole.Name);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
            }

            base.Seed(context);
        }
    }
}