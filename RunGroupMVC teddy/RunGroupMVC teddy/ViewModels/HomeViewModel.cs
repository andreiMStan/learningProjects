using RunGroupMVC_teddy.Models;

namespace RunGroupMVC_teddy.ViewModels
{
 public class HomeViewModel
 {
        public IEnumerable<Club> Clubs { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
