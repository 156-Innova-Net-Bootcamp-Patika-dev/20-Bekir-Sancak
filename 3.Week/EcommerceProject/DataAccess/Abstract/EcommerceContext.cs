using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    /// <summary>
    /// Veri tabanına bağlanmak ve Veri tabanı nesnelerimiz ile tablolarımızı ilişkilendirmek için 
    /// DbContext'ten miras alan bir EcommerceContext class oluşturduk.
    /// DbContext'tin OnConfiguring metodunu override ettik.
    /// DbSet ile veritabanı nesneleri ile Tabloları birbirine bağladık.
    /// </summary>
    public class EcommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=DESKTOP-69SNK4H;Database=Ecommerce;Trusted_Connection=true");
        }

        public  DbSet<Brand>  Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        

    }
}
