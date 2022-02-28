using SiteManagement.Application.Contracts.Persistence.Repositories.InvoiceTypes;
using SiteManagement.Domain.Entities.Invoices;
using SiteManagement.Domain.Entities.InvoiceTypes;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Infrastructure.Contracts.Persistence.Repositories.InvoiceTypes
{
    public class InvoiceTypeRepository : RepositoryBase<InvoiceType>, IInvoiceTypeRepository
    {
        public InvoiceTypeRepository(SiteManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
