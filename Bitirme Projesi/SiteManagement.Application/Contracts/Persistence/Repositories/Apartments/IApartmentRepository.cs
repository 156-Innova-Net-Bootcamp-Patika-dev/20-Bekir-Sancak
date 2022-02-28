using SiteManagement.Application.Contracts.Persistence.Repositories.Commons;
using SiteManagement.Domain.Entities.Apartmens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Contracts.Persistence.Repositories.Apartments
{
    public interface IApartmentRepository: IRepositoryBase<Apartment>
    {
        Task<Apartment> GetApartmentById(int apartmentId);
        Task<IList<Apartment>> GetApartmentList();
    }
}
