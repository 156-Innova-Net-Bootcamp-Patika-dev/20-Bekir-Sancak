using SiteManagement.Domain.Entities.Apartmens;
using SiteManagement.Domain.Entities.Commons;
using SiteManagement.Domain.Entities.InvoiceTypes;
using SiteManagement.Domain.Entities.ProcessTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain.Entities.Invoices
{
    public class Invoice:EntityBase
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        public int ApartmentId { get; set; }

        public Apartment Apartment { get; set; }
        public int Month { get; set; }

        public double Price { get; set; }  


        public int InvoiceTypeId { get; set; }

        public InvoiceType InvoiceType { get; set; }

        public int ProcessTypeId { get; set; }
        public ProcessType ProcessType { get; set; }

        public bool IsPaid { get; set; }


       







    }
}
