using E_CommercaAPI.Application.Repositories;
using E_CommerceAPI.Domain.Common;
using E_CommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Persistance.Repositories
{
    public class ReadRepository<T>(ECommerceAPIDbContext _context) : IReadRepository<T> where T : BaseEntity
    {
        

        public Microsoft.EntityFrameworkCore.DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table;
        }
        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }

        public async Task<T> GetSingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> method)
        {
            return await Table.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
    }
}
