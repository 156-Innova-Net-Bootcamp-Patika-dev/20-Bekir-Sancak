using SiteManagement.Application.Contracts.Persistence.Repositories.ProcessTypes;
using SiteManagement.Domain.Entities.ProcessTypes;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Infrastructure.Contracts.Persistence.Repositories.ProcessTypess
{
    public class ProcessTypeRepository : RepositoryBase<ProcessType>,IProcessTypeRepository
    {
        public ProcessTypeRepository(SiteManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
