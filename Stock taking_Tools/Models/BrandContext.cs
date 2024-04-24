using Microsoft.EntityFrameworkCore;

namespace Stock_taking_Tools.Models
{
    public class BrandContext : DbContext 
    {
        public BrandContext(DbContextOptions<BrandContext> Options) : base(Options) 

        {

        }
        
        public DbSet<Brand> Brands { get; set; }

    }
}
