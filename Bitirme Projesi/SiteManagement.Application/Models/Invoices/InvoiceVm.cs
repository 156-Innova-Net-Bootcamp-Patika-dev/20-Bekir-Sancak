using SiteManagement.Application.Models.Apartments;
using SiteManagement.Application.Models.InvoiceTypes;
using SiteManagement.Application.Models.ProcessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Models.Invoices
{
    public class InvoiceVm
    {
        public int InvoiceId { get; set; }

        public InvoiceTypeVm InvoiceType { get; set; }

        public ProcessTypeVm ProcessType { get; set; }

        public ApartmentVm Apartment { get; set; }
        public int Month { get; set; }

        public float Price { get; set; }

        public bool IsPaid { get; set; }

      
    }
}
