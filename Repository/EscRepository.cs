using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class EscRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Esc> Escs
        {
            get
            {
                return _database.GetCollection<Esc>("escs");
            }
        }

        public EscRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public Esc Add(Esc item)
        {
            Escs.InsertOne(item);
            return item;
        }

        public IEnumerable<Esc> GetAll()
        {
            return Escs.Find(FilterDefinition<Esc>.Empty).ToList();
        }

        public Esc Get(long id)
        {
            var filter = Builders<Esc>.Filter.Eq(a => a.Id, id);
            return Escs.Find(filter).FirstOrDefault();
        }

        public void Update(long id, Esc item)
        {
            var filter = Builders<Esc>.Filter.Eq(a => a.Id, id);
            var update = Builders<Esc>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.Weight, item.Weight)
                .Set(x => x.MaxCurrent, item.MaxCurrent)
                .Set(x => x.AllInOne, item.AllInOne)
                .Set(x => x.EscProtocol, item.EscProtocol)
                .Set(x => x.LipoVoltage, item.LipoVoltage)
                .Set(x => x.EscFirmware, item.EscFirmware)
                .Set(x => x.Chip, item.Chip);

            var updateResult = Escs.UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Esc>.Filter.Eq(a => a.Id, id);
            Escs.DeleteOne(filter);
        }
    }
}