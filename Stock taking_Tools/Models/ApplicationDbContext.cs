using Microsoft.EntityFrameworkCore;

namespace Stock_taking_Tools.Models
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }
        
        public DbSet<Tool> Tools { get; set; }

    }
}
