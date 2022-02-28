using SiteManagement.Domain.Entities.Apartmens;
using SiteManagement.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain.Entities.Owners
{
    public class Owner:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }
        public string Name { get; set; }

      
        public  ICollection<Apartment> Apartment { get; set; }
    }
}
