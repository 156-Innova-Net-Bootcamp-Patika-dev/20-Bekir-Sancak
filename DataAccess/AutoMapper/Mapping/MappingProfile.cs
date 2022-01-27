using AutoMapper;
using DataAccess.Models.Brands;
using DataAccess.Models.Category;
using DataAccess.Models.Products;
using Entities.Concrate;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AutoMapper.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //---Brand
            CreateMap<Brand, BrandsVm>().ReverseMap().ForAllOtherMembers(x => x.Ignore());
            CreateMap<Brand,BrandDetailVm>().ReverseMap().ForAllOtherMembers(y => y.Ignore());
            CreateMap<CreateBrandVm, Brand>().ReverseMap().ForAllOtherMembers(y => y.Ignore()); ;
            CreateMap<UpdateBrandVm, Brand>().ReverseMap().ForAllOtherMembers(y => y.Ignore()); ;

            //---Categories
            CreateMap<Category,CategorysVm>().ReverseMap().ForAllOtherMembers(x => x.Ignore());
            CreateMap<Category,CategoryDetailVm>().ReverseMap().ForAllOtherMembers(x => x.Ignore());
            CreateMap<CreateCategoryVm, Category>().ReverseMap().ForAllOtherMembers(x => x.Ignore());
            CreateMap<UpdateCategoryVm,Category>().ReverseMap().ForAllOtherMembers(x => x.Ignore());

            //---Products
            CreateMap<ProductDetailDto,ProductsVm>().ReverseMap().ForAllOtherMembers(x => x.Ignore());
            CreateMap<ProductDetailDto, ProductDetailVm>().ReverseMap().ForAllOtherMembers(x => x.Ignore());
            CreateMap<CreateProductVm, Product>().ReverseMap().ForAllOtherMembers(x => x.Ignore());
            CreateMap<UpdateProductVm, Product>().ReverseMap().ForAllOtherMembers(x => x.Ignore());
        }
    }
}
