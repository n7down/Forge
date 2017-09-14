using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Forge.Models
{
    public class TransmitterContext : DbContext
    {
        public TransmitterContext(DbContextOptions<TransmitterContext> options) : base(options)
        {
        }

        public DbSet<Transmitter> Transmitters { get; set; }
    }
}
