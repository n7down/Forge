using Microsoft.EntityFrameworkCore;

namespace Forge.Models
{
    public class FlightControllerContext : DbContext
    {
        public FlightControllerContext(DbContextOptions<FlightControllerContext> options) : base(options)
        {
        }

        public DbSet<FlightController> FlightControllers { get; set; }
    }
}
