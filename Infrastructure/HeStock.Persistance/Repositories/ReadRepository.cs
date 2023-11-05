using HeStock.Application.Repositories;
using HeStock.Domain.Entities.Common;
using HeStock.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace HeStock.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly HeStockDbContext _context;

        public ReadRepository(HeStockDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return expression == null 
                ? await query.ToListAsync()
                    : await query.Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);

            if (!tracking)
                query = Table.AsNoTracking();

            return query;
        }
    }
}
