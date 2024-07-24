using Microsoft.EntityFrameworkCore;
using RealEstate.Server.Model.PropertyDetails;

namespace RealEstate.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
       : base(options)
        {
        }

        public DbSet<Property> Property { get; set; }
    }
}
