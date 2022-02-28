using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.Messages;
using SiteManagement.Domain.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Messages.DeleteMessage
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<DeleteMessageCommand> _logger;
        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var deleteMessage = await _messageRepository.Get(c => c.MessageId == request.MessageId && c.ReceivingId == request.UserId);
            if(deleteMessage == null)
                throw new Exception("Message not found in the system ");

            await  _messageRepository.RemoveAsync(deleteMessage);
            _logger.LogInformation($"Message {deleteMessage.MessageId} is successfully deleted.");
         return Unit.Value;
        }
    }
}
