using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class TransmitterRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Transmitter> Transmitters
        {
            get
            {
                return _database.GetCollection<Transmitter>("transmitters");
            }
        }

        public TransmitterRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public Transmitter Add(Transmitter item)
        {
            Transmitters.InsertOne(item);
            return item;
        }

        public IEnumerable<Transmitter> GetAll()
        {
            return Transmitters.Find(FilterDefinition<Transmitter>.Empty).ToList();
        }

        public Transmitter Get(long id)
        {
            var filter = Builders<Transmitter>.Filter.Eq(a => a.Id, id);
            return Transmitters.Find(filter).FirstOrDefault();
        }

        public void Update(long id, Transmitter item)
        {
            var filter = Builders<Transmitter>.Filter.Eq(a => a.Id, id);
            var update = Builders<Transmitter>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.Weight, item.Weight)
                .Set(x => x.NumberChannels, item.NumberChannels)
                .Set(x => x.Voltage, item.Voltage);

            var updateResult = Transmitters.UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Transmitter>.Filter.Eq(a => a.Id, id);
            Transmitters.DeleteOne(filter);
        }
    }
}