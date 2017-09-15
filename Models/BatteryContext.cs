using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Forge.Models
{
    public class BatteryContext : DbContext
    {
        private readonly IMongoDatabase _database = null;
        public BatteryContext()
        {
            try
            {
                // var client = new MongoClient(settings.Value.ConnectionString);
                // if (client != null)
                // {
                //     _database = client.GetDatabase(settings.Value.Database);
                // }
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost"));
                MongoClient mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase("qcwdb");
            } 
            catch(Exception e)
            {
                throw new Exception("could not access the db server", e);
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
