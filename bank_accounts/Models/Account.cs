using System;
using System.ComponentModel.DataAnnotations;

namespace bank_accounts.Models
{
    public class Account : BaseEntity
    {
        public int AccountId { get; set; }

        public double Balance { get; set; }
        
        public double Transaction { get; set; }

        public string TransactionDate { get; set; }
 
        public int UserId { get; set; }

    }
}