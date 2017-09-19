using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class MotorRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Motor> Motors
        {
            get
            {
                return _database.GetCollection<Motor>("motors");
            }
        }

        public MotorRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public Motor Add(Motor item)
        {
            Motors.InsertOne(item);
            return item;
        }

        public IEnumerable<Motor> GetAll()
        {
            return Motors.Find(FilterDefinition<Motor>.Empty).ToList();
        }

        public Motor Get(long id)
        {
            var filter = Builders<Motor>.Filter.Eq(a => a.Id, id);
            return Motors.Find(filter).FirstOrDefault();
        }

        public void Update(long id, Motor item)
        {
            var filter = Builders<Motor>.Filter.Eq(a => a.Id, id);
            var update = Builders<Motor>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.Model, item.Model)
                .Set(x => x.Kv, item.Kv)
                .Set(x => x.Weight, item.Weight)
                .Set(x => x.LipoVoltage, item.LipoVoltage);

            var updateResult = Motors.UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Motor>.Filter.Eq(a => a.Id, id);
            Motors.DeleteOne(filter);
        }
    }
}