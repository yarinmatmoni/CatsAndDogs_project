using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs.Models
{ 
    //eden
    public class User
    {
        public enum UserType{
            Admin,
            Editor,
            Client
        }

        public int Id{ get; set; }

        [Required]
        public string Username{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserType Type { get; set; } = UserType.Client;

    }
}
