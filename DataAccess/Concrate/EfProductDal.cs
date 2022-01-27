using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Dto;

namespace DataAccess.Concrate
{
    public class EfProductDal : EfEntityRepositoryBase<Product, EcommerceContext>, IProductDal
    {
        public ProductDetailDto GetByName(Func<ProductDetailDto, bool> filter = null)
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                var product = (from p in context.Products
                               join c in context.Categories on p.CategoryId equals c.CategoryId
                               join b in context.Brands on p.BrandId equals b.BrandId
                               where p.ProductName == filter.ToString()
                               select new ProductDetailDto
                               {
                                   ProductId = p.ProductId,
                                   ProductName = p.ProductName,
                                   CategoryId = p.CategoryId,
                                   CategoryName = c.CategoryName,
                                   BrandId = p.BrandId,
                                   BrandName = b.BrandName,
                                   UnitPrice = p.UnitPrice,
                                   UnitInStock = p.UnitInStock,
                                   Description = p.Description,
                                   IsActive = p.IsActive


                               }).FirstOrDefault();
                return product;
            }

           
        }
        public ProductDetailDto GetProduct(int productId)
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                var product = (from p in context.Products
                               join c in context.Categories on p.CategoryId equals c.CategoryId
                               join b in context.Brands on p.BrandId equals b.BrandId
                               where p.ProductId == productId
                               select new ProductDetailDto
                               {
                                   ProductId = p.ProductId,
                                   ProductName = p.ProductName,
                                   CategoryId = p.CategoryId,
                                   CategoryName = c.CategoryName,
                                   BrandId = p.BrandId,
                                   BrandName = b.BrandName,
                                   UnitPrice = p.UnitPrice,
                                   UnitInStock = p.UnitInStock,
                                   Description = p.Description,
                                   IsActive = p.IsActive


                               }).FirstOrDefault();
                return product;

            }
        }

        public List<ProductDetailDto> GetProducts(Func<ProductDetailDto, bool> filter = null)
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                var products = (from p in context.Products
                                join c in context.Categories on p.CategoryId equals c.CategoryId
                                join b in context.Brands on p.BrandId equals b.BrandId
                                select new ProductDetailDto
                                {
                                    ProductId = p.ProductId,
                                    ProductName = p.ProductName,
                                    CategoryId = p.CategoryId,
                                    CategoryName = c.CategoryName,
                                    BrandId = p.BrandId,
                                    BrandName = b.BrandName,
                                    UnitPrice = p.UnitPrice,
                                    UnitInStock = p.UnitInStock,
                                    Description = p.Description,
                                    IsActive = p.IsActive


                                }).ToList();
                return products;

            }

        }
    }
}
