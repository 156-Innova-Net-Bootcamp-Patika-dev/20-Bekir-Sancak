using SiteManagement.Application.Contracts.Persistence.Repositories.Owners;
using SiteManagement.Domain.Entities.Owners;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Owners
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(SiteManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
