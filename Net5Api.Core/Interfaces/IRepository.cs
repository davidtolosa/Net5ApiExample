using Net5Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5Api.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task Add(T entity);

        public Task Delete(int id);
        
        IEnumerable<T> GetAll();

        public Task<T> GetById(int id);

        public void Update(T entity);
    }
}