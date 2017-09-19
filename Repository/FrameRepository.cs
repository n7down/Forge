using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class FrameRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Frame> Frames
        {
            get
            {
                return _database.GetCollection<Frame>("frames");
            }
        }

        public FrameRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public Frame Add(Frame item)
        {
            Frames.InsertOne(item);
            return item;
        }

        public IEnumerable<Frame> GetAll()
        {
            return Frames.Find(FilterDefinition<Frame>.Empty).ToList();
        }

        public Frame Get(long id)
        {
            var filter = Builders<Frame>.Filter.Eq(a => a.Id, id);
            return Frames.Find(filter).FirstOrDefault();
        }

        public void Update(long id, Frame item)
        {
            var filter = Builders<Frame>.Filter.Eq(a => a.Id, id);
            var update = Builders<Frame>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.Weight, item.Weight);

            var updateResult = Frames.UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Frame>.Filter.Eq(a => a.Id, id);
            Frames.DeleteOne(filter);
        }
    }
}