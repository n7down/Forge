using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Forge.Models
{
    public class ReceiverContext : DbContext
    {
        public ReceiverContext(DbContextOptions<ReceiverContext> options) : base(options)
        {
        }

        public DbSet<Receiver> Receivers { get; set; }
    }
}
