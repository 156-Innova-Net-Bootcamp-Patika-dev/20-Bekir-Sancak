using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Category
{
    public class UpdateCategoryVm
    {
        [Required(ErrorMessage = "Lütfen bir CategoryId giriniz")]
        public int CategoryId { get; set; }

        [Display(Name = "CategoryName")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} {1} ila {2} karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Lütfen CategoryName giriniz.")]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
