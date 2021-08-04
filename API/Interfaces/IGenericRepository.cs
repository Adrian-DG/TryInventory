using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(object id);
        Task Insert(T model);
        Task Delete(object id);
        void Update(T model);
    }
}