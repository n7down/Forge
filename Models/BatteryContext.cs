using Microsoft.EntityFrameworkCore;

namespace Forge.Models
{
    public class BatteryContext : DbContext
    {
        public BatteryContext(DbContextOptions<BatteryContext> options) : base(options)
        {
        }

        public DbSet<Battery> Batteries { get; set; }
    }
}
