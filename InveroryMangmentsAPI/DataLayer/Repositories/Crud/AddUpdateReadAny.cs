using DataLayer.Data;
using DataLayer.Interfaces.ICrud;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Crud
{
    public class AddUpdateReadAny<T> : IAddUpdateReadAny<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        
        public AddUpdateReadAny(AppDbContext context) 
        {
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task< bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public IQueryable<T> Pagination(int pageNumber, int pageSize)
        {
            return _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

       public IQueryable<T> QueryCustom(Expression<Func<T, bool>> predicate, bool AsNoTracking)
        {
            if (AsNoTracking)
            {
                return _dbSet.AsNoTracking().Where(predicate);
            }
            else
            {
                return _dbSet.Where(predicate);
            }
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
