﻿using Microsoft.AspNetCore.Identity;
using RunGroupMVC_teddy.Data.Enum;
using RunGroupMVC_teddy.Models;

namespace RunGroupMVC_teddy.Data
{
 public class Seed
 {
  public static void SeedData(IApplicationBuilder applicationBuilder)
  {
   using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
   {
    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    context.Database.EnsureCreated();
    if (!context.Clubs.Any())
    {
     context.Clubs.AddRange(new List<Club>()
      {
      new Club()
      {
       Title="Running club 1 ",
       Image="https://www.eatthis.com/wp-content/uploads/site/4/2020/05/running.jpg",
       Description="This is the description of the first cinema",
       ClubCategory=ClubCategory.City,
       Address=new Address()
       {
        Street="123 MAIN STREET",
        City="Alba",
        State="Ireland"
       }
      },
            new Club()
      {
       Title="Running club 2 ",
       Image="https://www.eatthis.com/wp-content/uploads/site/4/2020/05/running.jpg",
       Description="This is the description of the first cinema",
       ClubCategory=ClubCategory.Endurance,
       Address=new Address()
       {
        Street="123 MAIN STREET",
        City="Alba",
        State="Ireland"
       }
      },
                 new Club()
      {
       Title="Running club 3 ",
       Image="https://www.eatthis.com/wp-content/uploads/site/4/2020/05/running.jpg",
       Description="This is the description of the first cinema",
       ClubCategory=ClubCategory.Trail,
       Address=new Address()
       {
        Street="123 MAIN STREET",
        City="Alba",
        State="Ireland"
       }
      },
        new Club()
      {
       Title="Running club 4 ",
       Image="https://www.eatthis.com/wp-content/uploads/site/4/2020/05/running.jpg",
       Description="This is the description of the first cinema",
       ClubCategory=ClubCategory.City,
       Address=new Address()
       {
        Street="123 MAIN STREET",
        City="Alba",
        State="Ireland"
       }
      }
     });
     context.SaveChanges();

    }
    //Races
    if (!context.Races.Any())
    {
     context.Races.AddRange(new List<Race>()
     {
      new Race()
      {
       Title="Running Race 1",
       Image="https://www.eatthis.com/wp-content/uploads/sites/4/2020/5/running.jpg",
       Description="This is the description of the race",
       RaceCategory=RaceCategory.Marathon,
       Address=new Address()
       {
        Street="asdasds",
        City="asdsads"
        ,State="asdasd"
       }
      },
      new Race()
      {
       Title="Running Race 2",
       Image="https://www.eatthis.com/wp-content/uploads/sites/4/2020/5/running.jpg",
       Description="This is the description of the race",
       RaceCategory=RaceCategory.Ultra,
       Address=new Address()
       {
        Street="asdasds",
        City="asdsads"
        ,State="asdasd"
       }
      }
     });
     context.SaveChanges();
    }
   }
  }
     public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    {
     using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
     {
      //Roles
      var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
      if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
       await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

      if (!await roleManager.RoleExistsAsync(UserRoles.User))
       await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

      //Users
      var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
      string adminUserEmail = "andrdsfei@yahoo.com";
      var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
      if (adminUser == null)
      {
       var newAdminUser = new AppUser()
       {
        UserName = "andrei",
        Email = adminUserEmail,
        EmailConfirmed = true,
        Address=new Address()
        {
          Street="asasdsad",
          City="asdsad",
          State="Nsa"
        }
       };
    
     await userManager.CreateAsync(newAdminUser, "Andrei@1235?");
       await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
      }
      string appUserEmail = "userds@tickets.com";
      var appUser = await userManager.FindByEmailAsync(appUserEmail);

      if (appUser == null)
      {
       var newAppUser = new AppUser()
       {
        UserName = "app-user",
        Email = appUserEmail,
        EmailConfirmed = true,
        Address = new Address()
        {
         Street = "asasdsad",
         City = "asdsad",
         State = "Nsa"
        }
       };

       await userManager.CreateAsync(newAppUser, "Andrei@1235?");
       await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
      }

 
       }
     }
 }

}
