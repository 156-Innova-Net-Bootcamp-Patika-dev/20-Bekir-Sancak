using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    /// <summary>
    /// Service ve Manager ve Dallarımızın startup'ta çalışabilmesi için IServiceCollection'u genişlettik.
    /// Startup'a AddBusinessDepencyResolvers'ı ekledik
    /// </summary>
    public static class BusinessDepencyResolvers
    {
        public static IServiceCollection AddBusinessDepencyResolvers(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandDal, EfBrandDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            return services;
        }
    }
}
