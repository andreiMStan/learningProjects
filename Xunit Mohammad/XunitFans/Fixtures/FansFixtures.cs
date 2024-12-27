using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unit_Moh.Models;

namespace XunitFans.Fixtures
{
 public class FansFixtures
 {

  public static List<Fan> GetFans() => new() {
  new Fan()
  {
    Email = "andrei@test.com",
     Id = 1,
     Name = "Andrei"
    }
  ,new Fan()
  {
    Email = "andreasdsai@test.com",
     Id = 3,
     Name = "asdsa"
    },
  new Fan()
  {
    Email = "andasdsarei@test.com",
     Id = 2,
     Name = "asd"
    }
 };
 } 
}
