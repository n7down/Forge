using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
