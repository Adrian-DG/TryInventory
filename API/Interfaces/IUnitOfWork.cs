using System;
using System.Threading.Tasks;
using API.Repositories;

namespace API.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : class 
    {
        IGenericRepository<T> Repository { get; }
        Task<bool> CommitChanges();
    }
}