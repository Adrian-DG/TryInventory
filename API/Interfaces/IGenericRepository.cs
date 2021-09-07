using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.DTO;

namespace API.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(QueryParams parameters);
        Task<T> GetById(object id);
        Task Insert(T model);
        Task Delete(object id);
        void Update(T model);
    }
}