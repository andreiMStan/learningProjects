﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RunGroupMVC_teddy.Models;

namespace RunGroupMVC_teddy.Data
{
 public class ApplicationDbContext:IdentityDbContext<AppUser>
 {
        public ApplicationDbContext
   (DbContextOptions <ApplicationDbContext> options)
   :base(options)
        {
        }

     public DbSet<Race>Races { get; set; }
     public DbSet<Club> Clubs { get; set; }
     public DbSet<Address> Addresses { get; set; }

 }
}