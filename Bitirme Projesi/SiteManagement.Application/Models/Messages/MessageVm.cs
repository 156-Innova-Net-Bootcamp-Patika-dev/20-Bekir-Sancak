using SiteManagement.Application.Models.Authentications;
using SiteManagement.Domain.Enum.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Models.Messages
{
    public class MessageVm
    {
        public int MessageId { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public int Status { get; set; }

        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case (int)MessageStatusEnum.Unread:
                        {
                            return "Unread";
                        }
                    case (int)MessageStatusEnum.Read:
                        {
                            return "Read";
                        }
                }

                return "";

            }
        }
        public UserVm Sender { get; set; }

        public UserVm Receiving { get; set; }
        public bool IsRead { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
