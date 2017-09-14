using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Forge.Models
{
    public class EscContext : DbContext
    {
        public EscContext(DbContextOptions<EscContext> options) : base(options)
        {
        }

        public DbSet<Esc> Escs { get; set; }
    }
}
