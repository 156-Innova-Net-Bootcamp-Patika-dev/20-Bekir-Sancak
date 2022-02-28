using SiteManagement.Application.Contracts.Persistence.Repositories.Commons;
using SiteManagement.Domain.Entities.InvoiceTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Contracts.Persistence.Repositories.InvoiceTypes
{
    public interface IInvoiceTypeRepository:IRepositoryBase<InvoiceType>
    {
    }
}
