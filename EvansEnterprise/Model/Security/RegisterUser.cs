using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvansEnterprise.Model
{
    public class RegisterUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
      
        [Required]
        public string Password { get; set; }
    }
}
//^(.{0,7}|[^0-9]*|[^A-Z]*|[a-zA-Z0-9]*)$