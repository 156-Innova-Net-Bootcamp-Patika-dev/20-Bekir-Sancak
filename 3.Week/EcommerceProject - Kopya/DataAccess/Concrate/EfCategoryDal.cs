using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate
{
    /// <summary>
    /// CRUD işlemleri için Category nesnesinin somutunu tanımladık.
    /// Veritabanına kaydetmek ve veri çekmek için EfEntityReposiyoryBase class'dan miras aldık.Ve IBrandDal'ı implemente ettik
    /// </summary>
    public class EfCategoryDal: EfEntityRepositoryBase<Category, EcommerceContext>, ICategoryDal
    {
    }
}
