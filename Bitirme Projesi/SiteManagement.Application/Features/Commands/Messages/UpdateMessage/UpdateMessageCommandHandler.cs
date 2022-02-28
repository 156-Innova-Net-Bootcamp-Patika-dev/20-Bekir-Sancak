using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.Messages;
using SiteManagement.Domain.Entities.Messages;
using SiteManagement.Domain.Enum.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Messages.UpdateMessage
{
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<UpdateMessageCommandHandler> _logger;

        public UpdateMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper, ILogger<UpdateMessageCommandHandler> logger)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var updateMessage = await _messageRepository.Get(c => c.MessageId == request.MessageId && c.ReceivingId == request.UserId);
            if(updateMessage == null)
                throw new Exception("Message not found in the system ");

            _mapper.Map(request, updateMessage, typeof(UpdateMessageCommand), typeof(Message));
             if(!updateMessage.IsRead)
            {
                updateMessage.IsRead = true;
                updateMessage.Status = (int)MessageStatusEnum.Read;
                await _messageRepository.UpdateAsync(updateMessage);
            }
            else
            {
                updateMessage.IsRead = false;
                updateMessage.Status = (int)MessageStatusEnum.Unread;
                await _messageRepository.UpdateAsync(updateMessage);
            }

            _logger.LogInformation($"InvoiceType {updateMessage.MessageId} is successfully updated.");
            return Unit.Value;

        }
    }
}

