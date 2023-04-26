using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleMVC.Models
{
    public class UserModel
    { 
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DOB{ get; set; }
        public string EmailId { get; set; }
        public long PhoneNumber { get; set; }
        public string Location { get; set; }
        public List<LocationModel> LocationList { get; set; }
    }
}
