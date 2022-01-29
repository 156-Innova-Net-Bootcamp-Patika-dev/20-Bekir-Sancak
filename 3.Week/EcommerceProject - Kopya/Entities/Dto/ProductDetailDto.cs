using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    /// <summary>
    /// ProductDetailDto bir Dto nesnesidir.
    /// Dto nesnesi olduğunu belirtmek için IDto 'den implemente ettik
    /// </summary>
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
