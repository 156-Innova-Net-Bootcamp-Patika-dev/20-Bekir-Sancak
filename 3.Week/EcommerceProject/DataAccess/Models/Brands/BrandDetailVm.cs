using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Brands
{
    public class BrandDetailVm
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
