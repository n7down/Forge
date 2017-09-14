using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Forge.Models
{
    public class CameraContext : DbContext
    {
        public CameraContext(DbContextOptions<CameraContext> options) : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }
    }
}
