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

namespace SiteManagement.Application.Features.Commands.Messages.AddMessage
{
    public class AddMessageCommandHandler : IRequestHandler<AddMessageCommand>
    {

        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<AddMessageCommandHandler> _logger;

        public AddMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper, ILogger<AddMessageCommandHandler> logger)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Message>(request);
            entity.Status =(int) MessageStatusEnum.Unread;
            var newMessage = await _messageRepository.AddAsync(entity);

            _logger.LogInformation($"Message {newMessage.MessageId} is successfully created.");

            return Unit.Value;
        }
    }
}
