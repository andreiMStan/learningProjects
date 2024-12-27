using CloudCustomers.Api.Models;

namespace CloudCustomers.Api.Fixtures
{
 public static class UsersFixture
 {
  public static List<User> GetTestUsers() =>
   new(){
    new User{
    Id=1,
    Name="Andrei",
    Address= new Address()
    {
     Street="sadsadsa",
     City="adsads",
     ZipCode="s112321"
    },
    Email="asdsadsa.com"
    },

     new User{
    Id=1,
    Name="asdsa",
    Address= new Address()
    {
     Street="sadsadsa",
     City="adsads",
     ZipCode="s112321"
    },
    Email="asdsadsa.com"
    },

      new User{
    Id=1,
    Name="asd",
    Address= new Address()
    {
     Street="sadsasdadsa",
     City="adsads",
     ZipCode="s112321"
    },
    Email="asdsadsa.com"
    }
   };



 }
}
