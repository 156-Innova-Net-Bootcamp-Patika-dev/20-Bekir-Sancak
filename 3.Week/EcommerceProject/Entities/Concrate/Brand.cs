using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrate
{
    /// <summary>
    /// Brand bir veritabanı nesnesidir.
    /// Veritabanı nesnesi olduğunu belirtmek için IEntity 'den implemente ettik
    /// </summary>
  public  class Brand:IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public bool IsActive  { get; set; } = true;
    }
}
