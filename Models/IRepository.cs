using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Forge.Models 
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task Add(T item);
        Task<UpdateResult> Update(string id, string body);
        Task<DeleteResult> Remove(string id);
    }
}