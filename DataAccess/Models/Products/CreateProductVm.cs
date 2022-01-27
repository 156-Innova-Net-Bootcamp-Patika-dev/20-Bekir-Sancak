using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Products
{
    public class CreateProductVm
    {

        [Required(ErrorMessage = "Lütfen bir CategoryId giriniz")]
        public int CategoryId { get; set; }


        [Display(Name = "ProductName")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} {1} ila {2} karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Lütfen ProductName giriniz.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Lütfen bir BrandId giriniz")]
        public int BrandId { get; set; }

        [Display(Name = "UnitPrice")]
        [Required(ErrorMessage = "Lütfen bir UnitPrice giriniz")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "UnitInStock")]
        [Required(ErrorMessage = "Lütfen bir UnitInStock giriniz")]
        public int UnitInStock { get; set; }
        
        public string Description { get; set; }

        [Display(Name = "IsActive")]
        [Required(ErrorMessage = "Lütfen bir IsActive giriniz")]
        public bool IsActive { get; set; }
    }
}
