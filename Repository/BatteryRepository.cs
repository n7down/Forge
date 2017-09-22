using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class BatteryRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Battery> Batteries
        {
            get
            {
                return _database.GetCollection<Battery>("batteries");
            }
        }

        public BatteryRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public Battery Add(Battery item)
        {
            Batteries.InsertOne(item);
            return item;
        }

        public IEnumerable<Battery> GetAll()
        {
            return Batteries.Find(FilterDefinition<Battery>.Empty).ToList();
        }

        public Battery Get(long id)
        {
            var filter = Builders<Battery>.Filter.Eq(a => a.Id, id);
            return Batteries.Find(filter).FirstOrDefault();
        }

        public void Update(long id, Battery item)
        {
            var filter = Builders<Battery>.Filter.Eq(a => a.Id, id);
            var update = Builders<Battery>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.LipoVoltage, item.LipoVoltage)
                .Set(x => x.MAh, item.MAh)
                .Set(x => x.CRating, item.CRating)
                .Set(x => x.PlugType, item.PlugType)
                .Set(x => x.Weight, item.Weight)
                .Set(x => x.Dimension, item.Dimension)
                .Set(x => x.Link, item.Link);

            var updateResult = Batteries.UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Battery>.Filter.Eq(a => a.Id, id);
            Batteries.DeleteOne(filter);
        }
    }
}