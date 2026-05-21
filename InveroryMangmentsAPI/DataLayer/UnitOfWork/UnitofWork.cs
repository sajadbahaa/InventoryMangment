using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Interfaces.IRepository;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public class UnitofWork : IUnitOfWork
    {
        readonly AppDbContext _dbContext;
        public ICategoryRepo CategoryRepository { get; }

        public UnitofWork(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
            CategoryRepository = new CategoryRepository(_dbContext);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
