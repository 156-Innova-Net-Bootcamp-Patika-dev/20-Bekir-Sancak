using Core.DataAccess;
using Entities;
using Entities.Concrate;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    /// <summary>
    /// CRUD işlemleri için Product nesnesinin soyutunu tanımladık.
    /// Ve IEntityRepository'den implemente ettik. 
    ///Oda bir T tipinde class olan newlenebilir,IEntity tipinde bir nesne istiyor.
    /// </summary>
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProducts(Func<ProductDetailDto, bool> filter = null);
        ProductDetailDto GetProduct(int productId);
        ProductDetailDto GetByName(Func<ProductDetailDto, bool> filter = null);
    }
}
