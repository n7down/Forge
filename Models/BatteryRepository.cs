using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Forge.Models
{
    public class BatteryRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Battery> GetBatteries()
        {
            return _database.GetCollection<Battery>("batteries");
        }

        public BatteryRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            _database = mongoClient.GetDatabase("qcwdb");

        }

        public Battery Add(Battery battery)
        {
            GetBatteries().InsertOne(battery);
            return battery;
        }

        public IEnumerable<Battery> GetAll()
        {
            return GetBatteries().Find(FilterDefinition<Battery>.Empty).ToList();
        }

        public Battery Get(long id)
        {
            var filter = Builders<Battery>.Filter.Eq(a => a.Id, id);
            return GetBatteries().Find(filter).FirstOrDefault();
        }

        public void Update(long id, Battery battery)
        {
            var filter = Builders<Battery>.Filter.Eq(a => a.Id, id);
            var update = Builders<Battery>.Update
                .Set(x => x.Name, battery.Name)
                .Set(x => x.LipoVoltage, battery.LipoVoltage)
                .Set(x => x.MAh, battery.MAh)
                .Set(x => x.CRating, battery.CRating)
                .Set(x => x.PlugType, battery.PlugType)
                .Set(x => x.Weight, battery.Weight)
                .Set(x => x.Dimension, battery.Dimension);

            var updateResult = GetBatteries().UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Battery>.Filter.Eq(a => a.Id, id);
            GetBatteries().DeleteOne(filter);
        }
    }
}