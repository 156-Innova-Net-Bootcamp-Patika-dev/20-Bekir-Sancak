using DataAccess.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    /// <summary>
    /// Web Api'ye verilerimizi service etmek için Product nesnesinin bir interface'sini tanımladık.
    /// Gerekli methodlarımızı yazdık
    /// </summary>
    public interface IProductService
    {
        List<ProductsVm> GetAll();

        ProductDetailVm GetById(int productId);

        ProductDetailVm GetByName(string productName);
        void Add(CreateProductVm createProductVm);
        void Update(UpdateProductVm updateProductVm);
        void Delete(int productId);
    }
}
