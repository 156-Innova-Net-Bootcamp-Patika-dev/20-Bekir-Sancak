
using SiteManagement.Domain.Entities.Commons;
using SiteManagement.Domain.Entities.Invoices;
using SiteManagement.Domain.Entities.InvoiceTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain.Entities.ProcessTypes
{
    public class ProcessType:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcessTypeId { get; set; }

        public string Name { get; set; }

        public ICollection<Invoice> Invoice { get; set; }








    }
}
