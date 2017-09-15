using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Forge.Models
{
    public class BatteryContext : DbContext
    {
        private readonly IMongoDatabase _database = null;
        public BatteryContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }
        public IMongoCollection<Battery> Batteries
        {
            get 
            {
                return _database.GetCollection<Battery>("batteries");
            }
        }
    }
}
