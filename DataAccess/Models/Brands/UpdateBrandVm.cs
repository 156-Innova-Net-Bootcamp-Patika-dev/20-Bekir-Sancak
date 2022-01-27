using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Brands
{
    public class UpdateBrandVm
    {
        [Required(ErrorMessage ="Lütfen bir BrandId giriniz")]
        public int BrandId { get; set; }
        [Display(Name = "BrandName")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} {1} ila {2} karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Lütfen BrandName giriniz.")]
        public string BrandName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
