using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class ReceiverRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Receiver> Receivers
        {
            get
            {
                return _database.GetCollection<Receiver>("receivers");
            }
        }

        public ReceiverRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public Receiver Add(Receiver item)
        {
            Receivers.InsertOne(item);
            return item;
        }

        public IEnumerable<Receiver> GetAll()
        {
            return Receivers.Find(FilterDefinition<Receiver>.Empty).ToList();
        }

        public Receiver Get(long id)
        {
            var filter = Builders<Receiver>.Filter.Eq(a => a.Id, id);
            return Receivers.Find(filter).FirstOrDefault();
        }

        public void Update(long id, Receiver item)
        {
            var filter = Builders<Receiver>.Filter.Eq(a => a.Id, id);
            var update = Builders<Receiver>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.Weight, item.Weight)
                .Set(x => x.InputVoltage, item.InputVoltage)
                .Set(x => x.Channels, item.Channels)
                .Set(x => x.Telemetry, item.Telemetry);

            var updateResult = Receivers.UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Receiver>.Filter.Eq(a => a.Id, id);
            Receivers.DeleteOne(filter);
        }
    }
}