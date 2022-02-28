using SiteManagement.Application.Models.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.JWT
{
    public interface ITokenHelper
    {
        string GenerateJwt(UserModel userModel);
    }
}
