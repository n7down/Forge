using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Forge.Models
{
    public class BatteryRepository : IRepository<Battery>
    {
        private readonly BatteryContext _context = null;

        public BatteryRepository(IOptions<Settings> settings)
        {
            _context = new BatteryContext(settings);
        }

        public List<Battery> GetAll()
        {
            return _context.Batteries.Find(m => true).ToList();
        }

        public Battery Get(long id)
        {
            return _context.Batteries.Find(m => m.Id == id).FirstOrDefault();
        }

        public void Add(Battery item)
        {
            _context.Batteries.InsertOne(item);
        }

        public void Update(long id, Battery item)
        {
            _context.Batteries.ReplaceOne(m => m.Id == id, item);
        }

        public void Remove(long id)
        {
            _context.Batteries.DeleteOne(m => m.Id == id);
        }
    }
}