using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Contracts.Persistence.Repositories.Apartments;
using SiteManagement.Domain.Entities.Apartmens;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Apartments
{
    public class ApartmentRepository : RepositoryBase<Apartment>, IApartmentRepository
    {
        private readonly SiteManagementContext _dbContext;
        public ApartmentRepository(SiteManagementContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Apartment> GetApartmentById(int apartmentId)
        {
            var apartment = await _dbContext.Apartments.Where(c => c.ApartmentId == apartmentId)
            .Include(c => c.User)
            .Include(c=> c.Owner).FirstOrDefaultAsync();

            return apartment;   
            
        }

        public async Task<IList<Apartment>> GetApartmentList()
        {
            var apartments = await _dbContext.Apartments
                             .Include(c => c.User)
                             .Include(c => c.Owner).ToListAsync();
            return apartments;
        }
    }
}
