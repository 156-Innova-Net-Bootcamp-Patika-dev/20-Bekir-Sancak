using SiteManagement.Application.Contracts.Persistence.Repositories.Commons;
using SiteManagement.Domain.Entities.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Contracts.Persistence.Repositories.Invoices
{
    public interface IInvoiceRepository:IRepositoryBase<Invoice>
    {

        Task<IList<Invoice>> GetInvoiceById(int userId);

        Task<IList<Invoice>> GetInvoiceList();

    }
}
