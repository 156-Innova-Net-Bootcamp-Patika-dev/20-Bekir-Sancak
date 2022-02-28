using SiteManagement.Application.Contracts.Persistence.Repositories.Commons;
using SiteManagement.Domain.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Contracts.Persistence.Repositories.Messages
{
    public interface IMessageRepository:IRepositoryBase<Message>
    {
        Task<IList<Message>> GetMessageListById(int userId);

        

    }
}
