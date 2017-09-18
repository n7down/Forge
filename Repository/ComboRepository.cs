using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class ComboRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Combo> Combos
        {
            get
            {
                return _database.GetCollection<Combo>("combos");
            }
        }

        public ComboRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public Combo Add(Combo item)
        {
            Combos.InsertOne(item);
            return item;
        }

        public IEnumerable<Combo> GetAll()
        {
            return Combos.Find(FilterDefinition<Combo>.Empty).ToList();
        }

        public Combo Get(long id)
        {
            var filter = Builders<Combo>.Filter.Eq(a => a.Id, id);
            return Combos.Find(filter).FirstOrDefault();
        }

        public void Update(long id, Combo item)
        {
            var filter = Builders<Combo>.Filter.Eq(a => a.Id, id);
            var update = Builders<Combo>.Update
                .Set(x => x.Name, item.Name);

            var updateResult = Combos.UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Combo>.Filter.Eq(a => a.Id, id);
            Combos.DeleteOne(filter);
        }
    }
}