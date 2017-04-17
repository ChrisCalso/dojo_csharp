using Microsoft.EntityFrameworkCore;
 
namespace restauranter.Models
{
    public class ReviewContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options) { }

        public DbSet<Review> review { get; set; }
    }
}