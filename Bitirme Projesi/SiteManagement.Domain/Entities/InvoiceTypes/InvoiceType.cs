
using SiteManagement.Domain.Entities.Commons;

using SiteManagement.Domain.Entities.Invoices;
using SiteManagement.Domain.Entities.ProcessTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain.Entities.InvoiceTypes
{
    public class InvoiceType:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Invoice> Invoice { get; set; }








    }
}
