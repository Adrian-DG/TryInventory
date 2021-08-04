using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApiContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(ApiContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Delete(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        
        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Insert(T model)
        {
            await _dbSet.AddAsync(model);
        }

        public void Update(T model)
        {
            _context.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}