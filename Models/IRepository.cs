using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Forge.Models 
{
    public interface IBatteryRepository
    {   
        List<Battery> GetAll();

        Battery Get(long id);

        void Add(Battery item);

        void Update(long id, Battery item);

        void Remove(long id);
    }
}