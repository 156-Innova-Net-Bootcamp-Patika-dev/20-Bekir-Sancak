using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Models.Authentications;
using SiteManagement.Domain.Entities.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Authentications.GetUsers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserVm>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<UserVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var list = await _userManager.Users.ToListAsync();
            return  _mapper.Map<List<UserVm>>(list);
            
        }
    }
}
