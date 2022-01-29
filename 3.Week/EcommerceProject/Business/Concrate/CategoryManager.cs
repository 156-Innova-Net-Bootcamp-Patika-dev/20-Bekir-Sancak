using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Models.Category;
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
    /// ICategoryService implemente ettik.
    /// Construct ile ICategoryDal ve IMapper'i injektion ettik.
    /// Veri tabanı nesnelerini mapledik
    /// </summary>
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }


        public List<CategorysVm> GetAll()
        {
            var categories = _categoryDal.GetAll();
            return _mapper.Map<List<CategorysVm>>(categories);
        }

        public CategoryDetailVm GetById(int categoryId)
        {
            var category = _categoryDal.Get(c => c.CategoryId == categoryId);
            if(category is null)
            
                throw new InvalidOperationException("Category bulunamadı");

            return _mapper.Map<CategoryDetailVm>(category);

        }
        public void Add(CreateCategoryVm createCategoryVm)
        {
            var category = _categoryDal.Get(c => c.CategoryName == createCategoryVm.CategoryName);
            if(category!=null)
                throw new InvalidOperationException("Category zaten var");

            category=   _mapper.Map<Category>(createCategoryVm);
            _categoryDal.Add(category);
        }


        public void Update(UpdateCategoryVm updateCategoryVm)
        {
            var category=_categoryDal.Get(c=> c.CategoryId==updateCategoryVm.CategoryId);
            if(category is null)
                throw new InvalidOperationException("Category bulunamadı");
            category= _mapper.Map<Category>(updateCategoryVm);
            _categoryDal.Update(category);

        }
        public void Delete(int categoryId)
        {
            var category = _categoryDal.GetById(categoryId);
            if(category is null)
                throw new InvalidOperationException("Silinecek category bulunamadı");

            _categoryDal.Delete(category);
        }

        public CategoryDetailVm GetByName(string categoryName)
        {
            var category = _categoryDal.Get(c => c.CategoryName.ToLower().Contains(categoryName.ToLower()));
            if (category is null)

                throw new InvalidOperationException("Category bulunamadı");

            return _mapper.Map<CategoryDetailVm>(category);
        }
    }
}
