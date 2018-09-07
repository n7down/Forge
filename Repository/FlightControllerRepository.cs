using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Forge.Models;
using MongoDB.Driver;

namespace Forge.Repository
{
    public class FlightControllerRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<FlightController> FlightControllers
        {
            get
            {
                return _database.GetCollection<FlightController>("flightcontrollers");
            }
        }

        public FlightControllerRepository(IOptions<Settings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(settings.Value.Database);
        }

        public FlightController Add(FlightController item)
        {
            FlightControllers.InsertOne(item);
            return item;
        }

        public IEnumerable<FlightController> GetAll()
        {
            return FlightControllers.Find(FilterDefinition<FlightController>.Empty).ToList();
        }

        public FlightController Get(string id)
        {
            var filter = Builders<FlightController>.Filter.Eq(a => a.Id, id);
            return FlightControllers.Find(filter).FirstOrDefault();
        }

        public void Update(string id, FlightController item)
        {
            var filter = Builders<FlightController>.Filter.Eq(a => a.Id, id);
            var update = Builders<FlightController>.Update
                .Set(x => x.Name, item.Name)
                .Set(x => x.MCU, item.MCU)
                .Set(x => x.GyroName, item.GyroName)
                .Set(x => x.OSD, item.OSD)
                .Set(x => x.OSDName, item.OSDName)
                .Set(x => x.PDB, item.PDB)
                .Set(x => x.LipoVoltage, item.LipoVoltage)
                .Set(x => x.SDCard, item.SDCard)
                .Set(x => x.Weight, item.Weight)
                .Set(x => x.NumberUARTS, item.NumberUARTS)
                .Set(x => x.Barometer, item.Barometer)
                .Set(x => x.PWM, item.PWM)
                .Set(x => x.SBUS, item.SBUS)
                .Set(x => x.DSMTwo, item.DSMTwo)
                .Set(x => x.LedStrip, item.LedStrip)
                .Set(x => x.VideoIn, item.VideoIn)
                .Set(x => x.VideoOut, item.VideoOut)
                .Set(x => x.Buzzer, item.Buzzer)
                .Set(x => x.NumberSoftSerial, item.NumberSoftSerial);

            var updateResult = FlightControllers.UpdateOne(filter, update);
        }

        public void Delete(string id)
        {
            var filter = Builders<FlightController>.Filter.Eq(a => a.Id, id);
            FlightControllers.DeleteOne(filter);
        }
    }
}
