using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SiteManagement.Domain.Entities.Authentications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Authentications.SignUpUser
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, int>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;

        public SignUpUserCommandHandler(UserManager<User> userManager, IMapper mapper, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<int> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request);
            userEntity.UserName = userEntity.Email;

            var userCreateResult= await _userManager.CreateAsync(userEntity,request.Password);
            if(userCreateResult.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);

                return user.Id;
            }
            return 0;
        }
    }
}
