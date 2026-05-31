using BussinesLayer.Interfaces;
using DataLayer.Interfaces.IRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.ServicesRegister
{
    static  public class ServiceRegister
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoyService, CategoryService>();
            services.AddScoped<IProductService,ProductService>();
            return services;
        }
    }
}
