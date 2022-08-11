using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManager.Models
{
    public class User : IModelsID
    {
        public int Id { get; set; }
        public static int IdCounter = 1;
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        
        public User(string username, string password, Role role)
        {
            Id = IdCounter++;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
