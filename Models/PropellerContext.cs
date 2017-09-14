using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Forge.Models
{
    public class PropellerContext : DbContext
    {
        public PropellerContext(DbContextOptions<PropellerContext> options) : base(options)
        {
        }

        public DbSet<Propeller> Propellers { get; set; }
    }
}
