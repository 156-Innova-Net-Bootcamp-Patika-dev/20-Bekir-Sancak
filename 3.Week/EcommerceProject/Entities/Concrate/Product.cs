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
    /// Category bir veritabanı nesnesidir.
    /// Veritabanı nesnesi olduğunu belirtmek için IEntity 'den implemente ettik
    /// </summary>
    public class Product:IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
