using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Models.Products;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    /// <summary>
    /// DataAccess'den CRUD işlemleri için bir Manager Class tanımladık.
    /// IProductService'den implemente ettik.
    /// Construct ile IProductDal ve IMapper'i injektion ettik.
    /// Veri tabanı nesnelerini  mapledik
    /// </summary>
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal,IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public List<ProductsVm> GetAll()
        {
            var products = _productDal.GetProducts();

            return _mapper.Map<List<ProductsVm>>(products);
        }

        public ProductDetailVm GetById(int productId)
        {
            var product = _productDal.GetProduct(productId);
            if(product is null)
                throw new InvalidOperationException("Product bulunamadı");
            return _mapper.Map<ProductDetailVm>(product);
        }
        public void Add(CreateProductVm createProductVm)
        {
            var product = _productDal.Get(p => p.ProductName == createProductVm.ProductName);
            if(product!=null)
                throw new InvalidOperationException("Product zaten var");
            product = _mapper.Map<Product>(createProductVm);
            _productDal.Add(product);
        }

        public void Update(UpdateProductVm updateProductVm)
        {
            var product = _productDal.Get(p => p.ProductId == updateProductVm.ProductId);
            if(product is null)
                throw new InvalidOperationException("Product bulunamadı");
            product = _mapper.Map<Product>(updateProductVm);
            _productDal.Update(product);
        }
        public void Delete(int productId)
        {
            var product = _productDal.GetById(productId);
            if (product is null)
                throw new InvalidOperationException("Silinecek product bulunamadı");

            _productDal.Delete(product);
        }

        public ProductDetailVm GetByName(string productName)
        {
            var product = _productDal.GetByName(p=> p.ProductName.ToLower().Contains(productName));
            if (product is null)
                throw new InvalidOperationException("Product bulunamadı");
            return _mapper.Map<ProductDetailVm>(product);
        }
    }
}
