using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrasturture.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsyc(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Haim",
                    Email = "hyymbwsymwn@google.com",
                    UserName="hyymbwsymwn@google.com",
                    Address = new Address
                    {
                        FirstName = "Haim",
                        LastName = "Ben simon",
                        Street ="Hanehalim 72",
                        City = "Jerusalem",
                        State="Israel",
                        ZipCode ="100100"
                        
                    }
                };
                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}