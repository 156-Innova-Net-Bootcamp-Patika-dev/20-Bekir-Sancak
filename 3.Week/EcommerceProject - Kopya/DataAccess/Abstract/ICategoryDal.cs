using Core.DataAccess;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    /// <summary>
    /// CRUD işlemleri için Category nesnesinin soyutunu tanımladık.
    /// Ve IEntityRepository'den implemente ettik. 
    ///Oda bir T tipinde class olan newlenebilir,IEntity tipinde bir nesne istiyor.
    /// </summary>
    public interface ICategoryDal:IEntityRepository<Category>
    {
    }
}
