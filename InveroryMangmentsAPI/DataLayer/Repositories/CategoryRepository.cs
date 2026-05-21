using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Interfaces.IRepository;
using DataLayer.Interfaces.UnitOfWork;
using DataLayer.Repositories.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryRepository : Query<Category>, ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) 
:base(context)        {
            
            _context = context;
        }
        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
        }

        public void Delete(Category entity)
        {
            _context.Categories.Remove(entity);
        }

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
        }


    }


}
