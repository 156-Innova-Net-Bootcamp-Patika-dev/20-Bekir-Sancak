using DataAccess.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    /// <summary>
    /// Web Api'ye verilerimizi service etmek için Category nesnesinin bir interface'sini tanımladık.
    /// Gerekli metotlarımızı yazdık
    /// </summary>
    public interface ICategoryService
    {
        List<CategorysVm> GetAll();
        CategoryDetailVm GetById(int categoryId);

        CategoryDetailVm GetByName(string  categoryName);
        void Add(CreateCategoryVm createCategoryVm);
        void Update(UpdateCategoryVm updateCategoryVm);
        void Delete(int categoryId);
    }
}
