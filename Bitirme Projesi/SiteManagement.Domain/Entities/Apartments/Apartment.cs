using SiteManagement.Domain.Entities.Authentications;
using SiteManagement.Domain.Entities.Commons;
using SiteManagement.Domain.Entities.Invoices;
using SiteManagement.Domain.Entities.Owners;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain.Entities.Apartmens
{
    public class Apartment:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApartmentId { get; set; }
        public char Block { get; set; }
        public string ApartmentType { get; set; }
        public int Floor { get; set; }
        public int No { get; set; }
        public int Status { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

       
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

       

    }
}
