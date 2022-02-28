using MediatR;
using SiteManagement.Application.Models.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Authentications.GetUsers
{
    public class GetUserListQuery:IRequest<List<UserVm>>
    {
    }
}
