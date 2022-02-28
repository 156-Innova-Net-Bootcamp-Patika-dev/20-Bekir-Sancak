using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Features.Commands.Authentications.SignUpUser;
using SiteManagement.Application.Features.Queries.Authentications.GetUser;
using SiteManagement.Application.Features.Queries.Authentications.GetUsers;
using SiteManagement.Application.JWT;
using System;
using System.Threading.Tasks;

namespace SiteManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenHelper _tokenHelper;

        public AuthController(IMediator mediator, ITokenHelper tokenHelper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _tokenHelper = tokenHelper;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpUserCommand signUpUserCommand)
        {
            var result = await _mediator.Send(signUpUserCommand);

            if (result != 0)
            {
                return Ok();
            }

            return BadRequest("User not created");
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            var query = new GetUserByEmailAndPasswordQuery(email, password);
            var userModel = await _mediator.Send(query);

            if (userModel != null)
            {
                return Ok(_tokenHelper.GenerateJwt(userModel));
            }

            return BadRequest("Email or password incorrect.");
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _mediator.Send(new GetUserListQuery()));
        }

    }
}
