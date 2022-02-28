using AutoMapper;
using MediatR;
using SiteManagement.Application.Contracts.Persistence.Repositories.Messages;
using SiteManagement.Application.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Messages.GetMessages
{
    public class GetMessageQueryListHandler : IRequestHandler<GetMessageListQuery, IList<MessageVm>>
    {

        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessageQueryListHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<IList<MessageVm>> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetMessageListById(request.UserId);

            return _mapper.Map<IList<MessageVm>>(messages);
        }
    }
}
