using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Forge.Models
{
    public class BatteryContext : DbContext
    {
        private readonly IMongoDatabase _database = null;
        public BatteryContext(DbContextOptions<BatteryContext> options, IOptions<Settings> settings) : base(options)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public DbSet<Battery> Batteries { get; set; }

        public IMongoCollection<Battery> Batteries2
        {
            get 
            {
                return _database.GetCollection<Battery>("batteries");
            }
        }
    }
}
