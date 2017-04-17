using System;
using System.ComponentModel.DataAnnotations;

namespace wall.Models
{
    public abstract class BaseEntity {}
    public class User
    {
        [Required]
        [MinLength(2)]
        public string First_Name { get; set; }
        
        [Required]
        [MinLength(2)]
        public string Last_Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password confirmation must match Password")]
        public string PasswordConfirmation { get; set; }

        public int id { get; set; }
    }
}