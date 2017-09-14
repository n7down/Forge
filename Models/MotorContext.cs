using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Forge.Models
{
    public class MotorContext : DbContext
    {
        public MotorContext(DbContextOptions<MotorContext> options) : base(options)
        {
        }

        public DbSet<Motor> Motors { get; set; }
    }
}
