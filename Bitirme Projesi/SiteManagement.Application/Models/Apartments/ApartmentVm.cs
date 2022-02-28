using SiteManagement.Application.Models.Authentications;
using SiteManagement.Application.Models.Owners;
using SiteManagement.Domain.Enum.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Models.Apartments
{
    public class ApartmentVm
    {
        public int ApartmentId { get; set; }
        public string Block { get; set; }
        public string ApartmentType { get; set; }
        public int Floor { get; set; }
        public int No { get; set; }
        public int Status { get; set; }

        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case (int)ApartmentStatusEnum.Emptyhouse:
                        {
                            return "Emptyhouse";
                        }
                    case (int)ApartmentStatusEnum.Fullhouse:
                        {
                            return "Fullhouse";
                        }
                }

                return "";

            }
        }
        public OwnerVm Owner { get; set; }

        public  UserVm User { get; set; }
    }
}
