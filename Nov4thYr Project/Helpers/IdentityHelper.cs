using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nov4thYr_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nov4thYr_Project.Helpers
{
    public class IdentityHelper
    {
        internal static void SeedIdentities(DbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(RoleNames.ROLE_ADMINISTRATOR))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMINISTRATOR));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_DOCTOR))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_DOCTOR));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_PATIENT))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_PATIENT));
            }

            string userName = "newadmin@admin.com";
            string password = "Admin1!";

            ApplicationUser user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };
                IdentityResult userResult = userManager.Create(user, password);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, RoleNames.ROLE_ADMINISTRATOR);
                }
            }
        }
    }
}