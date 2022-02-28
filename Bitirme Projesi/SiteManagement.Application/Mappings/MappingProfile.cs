using AutoMapper;
using SiteManagement.Application.Features.Commands.Apartments.AddApartment;
using SiteManagement.Application.Features.Commands.Apartments.UpdateApartment;
using SiteManagement.Application.Features.Commands.Authentications.SignUpUser;
using SiteManagement.Application.Features.Commands.Invoices.AddInvoice;
using SiteManagement.Application.Features.Commands.Invoices.UpdateInvoice;
using SiteManagement.Application.Features.Commands.InvoiceTypes.AddInvoiceType;
using SiteManagement.Application.Features.Commands.InvoiceTypes.UpdateInvoiceType;
using SiteManagement.Application.Features.Commands.Messages.AddMessage;
using SiteManagement.Application.Features.Commands.Messages.UpdateMessage;
using SiteManagement.Application.Features.Commands.Owners.AddOwner;
using SiteManagement.Application.Features.Commands.Owners.UpdateOwner;
using SiteManagement.Application.Features.Commands.ProcessTypes.AddProcessType;
using SiteManagement.Application.Features.Commands.ProcessTypes.UpdateProcessType;
using SiteManagement.Application.Models.Apartments;
using SiteManagement.Application.Models.Authentications;
using SiteManagement.Application.Models.InvoiceTypes;
using SiteManagement.Application.Models.Messages;
using SiteManagement.Application.Models.Owners;
using SiteManagement.Application.Models.ProcessTypes;
using SiteManagement.Domain.Entities.Apartmens;
using SiteManagement.Domain.Entities.Authentications;
using SiteManagement.Domain.Entities.Invoices;
using SiteManagement.Domain.Entities.InvoiceTypes;
using SiteManagement.Domain.Entities.Messages;
using SiteManagement.Domain.Entities.Owners;
using SiteManagement.Domain.Entities.ProcessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Authentications

            CreateMap<User, SignUpUserCommand>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, UserVm>().ReverseMap();
            CreateMap<UserVm, User>().ReverseMap();

            #endregion

            #region Apartments
            CreateMap<Apartment, ApartmentVm>().ReverseMap();
            CreateMap<Apartment,AddApartmentCommand>().ReverseMap();
            CreateMap<Apartment, UpdateApartmentCommand>().ReverseMap();


            #endregion


            #region Owners
            CreateMap<Owner, OwnerVm>().ReverseMap();
            CreateMap<Owner, AddOwnerCommand>().ReverseMap();
            CreateMap<Owner, UpdateOwnerCommand>().ReverseMap();
            #endregion


            CreateMap<Invoice, AddInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceCommand>().ReverseMap();

            #region InvoiceTypes
            CreateMap<InvoiceType, InvoiceTypeVm>().ReverseMap();
            CreateMap<InvoiceType, AddInvoiceTypeCommand>().ReverseMap();
            CreateMap<InvoiceType, UpdateInvoiceTypeCommand>().ReverseMap();


            #endregion
            #region ProcessTypes
            CreateMap<ProcessType, ProcessTypeVm>().ReverseMap();
            CreateMap<ProcessType, AddProcessTypeCommand>().ReverseMap();
            CreateMap<ProcessType, UpdateProcessTypeCommand>().ReverseMap();
            #endregion

            CreateMap<Message, AddMessageCommand>().ReverseMap();
            CreateMap<Message, UpdateMessageCommand>().ReverseMap();
            CreateMap<Message, MessageVm>().ReverseMap();
        }
    }
}
