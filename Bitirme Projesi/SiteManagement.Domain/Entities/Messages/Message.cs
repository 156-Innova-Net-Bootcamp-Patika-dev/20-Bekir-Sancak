using SiteManagement.Domain.Entities.Authentications;
using SiteManagement.Domain.Entities.Commons;
using SiteManagement.Domain.Enum.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Domain.Entities.Messages
{
    public class Message:EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

       [ForeignKey("SenderId")]
        public int? SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("ReceivingId")]
        public int? ReceivingId { get; set; }
        public User Receiving { get; set; }

        public int Status { get; set; }

       
        public bool IsRead { get; set; }

        public DateTime CreatedDate { get; set; }

       
    }
}
