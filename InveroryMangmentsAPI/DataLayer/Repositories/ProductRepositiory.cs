using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Interfaces.ICrud;
using DataLayer.Interfaces.IRepository;
using DataLayer.Repositories.Crud;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ProductRepositiory : AddUpdateReadAny<Products>,IProductRepo
    {
        private readonly AppDbContext _context;
        public ProductRepositiory(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
