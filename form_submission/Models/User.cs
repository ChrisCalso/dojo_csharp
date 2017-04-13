using System;
using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public abstract class BaseEntity {}
    public class User
    {
        [Required]
        [MinLength(4)]
        public string First_Name { get; set; }
        
        [Required]
        [MinLength(4)]
        public string Last_Name { get; set; }

        [Required]
        [Range(0,1000)]
        public string Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
    }
}