using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Forge.Models 
{
    public interface IRepository<T>
    {   
        List<T> GetAll();

        T Get(long id);

        void Add(T item);

        void Update(long id, T item);

        void Remove(long id);
    }
}