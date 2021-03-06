using System;
using System.ComponentModel.DataAnnotations;

namespace bank_accounts.Models
{
    public abstract class BaseEntity {}
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }
 
        public string Password { get; set; }

    }
}