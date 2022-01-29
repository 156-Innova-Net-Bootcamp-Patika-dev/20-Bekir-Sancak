using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Models.Brands;
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
    /// IBrandService implemente ettik.
    /// Construct ile IBranDal ve IMapper'i injektion ettik.
    /// Veri tabanı nesnelerini mapledik
    /// </summary>
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;

        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        public List<BrandsVm> GetAll()
        {
            var brands = _brandDal.GetAll();
            return _mapper.Map<List<BrandsVm>>(brands);


        }

        public BrandDetailVm GetById(int brandId)
        {
            var brand = _brandDal.Get(b => b.BrandId == brandId);
            if (brand is null)
                throw new InvalidOperationException("Brand bulunamadı");

            return _mapper.Map<BrandDetailVm>(brand);
        }

        public void Add(CreateBrandVm createBrand)
        {
            var brand = _brandDal.Get(b => b.BrandName == createBrand.BrandName);
            if(brand!=null)
                throw new InvalidOperationException("Brand zaten var");
            brand = _mapper.Map<Brand>(createBrand);

            _brandDal.Add(brand);


        }

        public void Delete(int brandId)
        {
            var brand = _brandDal.GetById(brandId);
            if(brand is null)
                throw new InvalidOperationException("Silinecek brand bulunamadı");

            _brandDal.Delete(brand);
        }

       
        public void Update(UpdateBrandVm updateBrand)
        {
            var brand = _brandDal.Get(b => b.BrandId==updateBrand.BrandId);
            if (brand is null)
                throw new InvalidOperationException("Brand bulunamadı");
            brand = _mapper.Map<Brand>(updateBrand);
            _brandDal.Update(brand);


        }

        public BrandDetailVm GetByName(string brandName)
        {
            var brand = _brandDal.Get(b => b.BrandName.ToLower().Contains(brandName.ToLower()));
            if (brand is null)
                throw new InvalidOperationException("Brand bulunamadı");

            return _mapper.Map<BrandDetailVm>(brand);
        }
    }
}
