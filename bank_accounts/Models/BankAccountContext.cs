using Microsoft.EntityFrameworkCore;
 
namespace bank_accounts.Models
{
    public class BankAccountContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankAccountContext(DbContextOptions<BankAccountContext> options) : base(options) { }

        public DbSet<User> user { get; set; }
        public DbSet<Account> account { get; set; }
    }
}