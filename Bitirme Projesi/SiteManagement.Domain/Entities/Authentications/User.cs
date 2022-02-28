using Microsoft.AspNetCore.Identity;
using SiteManagement.Domain.Entities.Apartmens;
using SiteManagement.Domain.Entities.Commons;
using SiteManagement.Domain.Entities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain.Entities.Authentications
{
    public class User: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }


      
        public ICollection<Apartment> Apartments { get; set; }

        [InverseProperty("Sender")]
        public ICollection<Message> SenderMessages { get; set; }

        [InverseProperty("Receiving")]
        public ICollection<Message> ReceivingMessages { get; set; }


    }
}
