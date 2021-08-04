using System.Threading.Tasks;
using API.Interfaces;
using API.Repositories;

namespace API.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private ApiContext _context;
        public IGenericRepository<T> Repository { get; }
        public UnitOfWork(ApiContext context, IGenericRepository<T> repository)
        {
            _context = context;
            Repository = repository;
        }

        public async Task<bool> CommitChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}