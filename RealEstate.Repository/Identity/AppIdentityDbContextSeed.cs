﻿using Microsoft.AspNetCore.Identity;
using RealEstate.Core.Entities.Identity;
namespace RealEstate.Repository.Identity;
public class AppIdentityDbContextSeed
{
    public static async Task SeedUserAsync(UserManager<AppUser> userManager)
    {
        if(!userManager.Users.Any())
        {
            var User = new AppUser()
            {
                DisplayName = "Omar Zakareia",
                Email = "omarzakareia868@gmail.com",
                UserName = "omarzakareia868",
                PhoneNumber = "01234567891",
            };
            await userManager.CreateAsync(User, "Pa$$w0rd");
        }
    }
}
