using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RunGroupMVC_teddy.Data;
using RunGroupMVC_teddy.Data.Enum;
using RunGroupMVC_teddy.Models;
using RunGroupMVC_teddy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RunGroopWebApp.Test.Repository
{
 public class ClubRepositoryTests

 {
  private async Task<ApplicationDbContext> GetDbContext()
  {
   var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
   var databaseContext = new ApplicationDbContext(options);
   databaseContext.Database.EnsureCreated();
   if (await databaseContext.Clubs.CountAsync() < 0)
   {
    for (int i = 0; i < 10; i++)
    {

     new Club()
     {
      Title = "Running club 1 ",
      Image = "https://www.eatthis.com/wp-content/uploads/site/4/2020/05/running.jpg",
      Description = "This is the description of the first cinema",
      ClubCategory = ClubCategory.City,
      Address = new Address()
      {
       Street = "123 MAIN STREET",
       City = "Alba",
       State = "Ireland"
      }
     };
     await databaseContext.SaveChangesAsync();
    }

   }
   return databaseContext;
  }

  [Fact]
  public async void ClubRepository_Add_ReturnsBool()
  {
   //Arrange
   var club = new Club()
   {
    Title = "Running club 1 ",
    Image = "https://www.eatthis.com/wp-content/uploads/site/4/2020/05/running.jpg",
    Description = "This is the description of the first cinema",
    ClubCategory = ClubCategory.City,
    Address = new Address()
    {
     Street = "123 MAIN STREET",
     City = "Alba",
     State = "Ireland"
    }
   };
   var dbContext = await GetDbContext();
   var clubRepository = new ClubRepository(dbContext);

   //Act
   var result = clubRepository.Add(club);

   //Assert
   result.Should().BeTrue();
  }


  [Fact]
  public async void ClubRepository_GetByIdAsync_ReturnsClub()
  {

   //Arrange
   var id = 1;
   var dbContext = await GetDbContext();
  
   //dbContext.Clubs.AsNoTracking();
   var clubRepository = new ClubRepository(dbContext);

   //Act
   var result = clubRepository.GetById(id);

   //Assert
   result.Should().NotBeNull();
   result.Should().BeOfType<Task<Club>>();
  }
 }
}