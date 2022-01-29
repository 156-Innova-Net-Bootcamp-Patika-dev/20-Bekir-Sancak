using DataAccess.Models.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    /// <summary>
    /// Web Api'ye verilerimizi service etmek için Brand nesnesinin bir interface'sini tanımladık.
    /// Gerekli metotlarımızı yazdık
    /// </summary>
  public interface IBrandService
    {
        List<BrandsVm> GetAll();
        BrandDetailVm GetById(int brandId);

        BrandDetailVm GetByName(string brandName);
        void Add(CreateBrandVm createBrand);
        void Update(UpdateBrandVm updateBrand);
        void Delete(int brandId);
    }
}
