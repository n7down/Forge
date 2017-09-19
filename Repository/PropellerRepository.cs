using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class PropellerRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Propeller> Propellers
        {
            get
            {
                return _database.GetCollection<Propeller>("propellers");
            }
        }

        public PropellerRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public Propeller Add(Propeller item)
        {
            Propellers.InsertOne(item);
            return item;
        }

        public IEnumerable<Propeller> GetAll()
        {
            return Propellers.Find(FilterDefinition<Propeller>.Empty).ToList();
        }

        public Propeller Get(long id)
        {
            var filter = Builders<Propeller>.Filter.Eq(a => a.Id, id);
            return Propellers.Find(filter).FirstOrDefault();
        }

        public void Update(long id, Propeller item)
        {
            var filter = Builders<Propeller>.Filter.Eq(a => a.Id, id);
            var update = Builders<Propeller>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.Diameter, item.Diameter)
                .Set(x => x.Pitch, item.Pitch)
                .Set(x => x.Blades, item.Blades)
                .Set(x => x.Material, item.Material)
                .Set(x => x.Shaft, item.Shaft);

            var updateResult = Propellers.UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Propeller>.Filter.Eq(a => a.Id, id);
            Propellers.DeleteOne(filter);
        }
    }
}