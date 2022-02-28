using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Contracts.Persistence.Repositories.Invoices;
using SiteManagement.Domain.Entities.Invoices;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Invoices
{
    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        private readonly SiteManagementContext _dbContext;
        public InvoiceRepository(SiteManagementContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Invoice>> GetInvoiceById(int userId)
        {
            var invoices = await _dbContext.Invoices.Where(c => c.Apartment.UserId == userId)
                 .Include(c => c.Apartment).Include(c => c.InvoiceType).Include(c => c.ProcessType).ToListAsync();

            return invoices;
        }

        public async Task<IList<Invoice>> GetInvoiceList()
        {
            var invoices = await _dbContext.Invoices
               .Include(c => c.Apartment).Include(c => c.InvoiceType).Include(c => c.ProcessType).ToListAsync();

            return invoices;

        }
    }
}
