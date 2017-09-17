using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class CameraRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<Camera> Cameras
        {
            get
            {
                return _database.GetCollection<Camera>("cameras");
            }
        }

        public CameraRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public Camera Add(Camera item)
        {
            Cameras.InsertOne(item);
            return item;
        }

        public IEnumerable<Camera> GetAll()
        {
            return Cameras.Find(FilterDefinition<Camera>.Empty).ToList();
        }

        public Camera Get(long id)
        {
            var filter = Builders<Camera>.Filter.Eq(a => a.Id, id);
            return Cameras.Find(filter).FirstOrDefault();
        }

        public void Update(long id, Camera item)
        {
            var filter = Builders<Camera>.Filter.Eq(a => a.Id, id);
            var update = Builders<Camera>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.IRBlock, item.IRBlock)
                .Set(x => x.Mic, item.Mic)
                .Set(x => x.Weight, item.Weight);

            var updateResult = Cameras.UpdateOne(filter, update);
        }

        public void Delete(long id)
        {
            var filter = Builders<Camera>.Filter.Eq(a => a.Id, id);
            Cameras.DeleteOne(filter);
        }
    }
}