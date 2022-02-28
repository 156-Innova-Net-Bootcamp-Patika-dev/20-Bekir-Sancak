using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Contracts.Persistence.Repositories.Messages;
using SiteManagement.Domain.Entities.Messages;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Messages
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        private readonly SiteManagementContext _dbContext;
        public MessageRepository(SiteManagementContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       

        public async Task<IList<Message>>GetMessageListById(int userId)
        {
            var messages = await _dbContext.Messages.Where(c => c.ReceivingId == userId || c.SenderId == userId)
                           .Include(c => c.Sender)
                           .Include(c => c.Receiving).ToListAsync();
            return messages;
        }
    }
}
