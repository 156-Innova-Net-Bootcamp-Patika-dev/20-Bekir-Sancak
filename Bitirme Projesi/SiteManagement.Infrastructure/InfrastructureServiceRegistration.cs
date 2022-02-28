using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Application.Contracts.Persistence.Repositories.Apartments;
using SiteManagement.Application.Contracts.Persistence.Repositories.Commons;
using SiteManagement.Application.Contracts.Persistence.Repositories.Invoices;
using SiteManagement.Application.Contracts.Persistence.Repositories.InvoiceTypes;
using SiteManagement.Application.Contracts.Persistence.Repositories.Messages;
using SiteManagement.Application.Contracts.Persistence.Repositories.Owners;
using SiteManagement.Application.Contracts.Persistence.Repositories.ProcessTypes;
using SiteManagement.Application.JWT;
using SiteManagement.Infrastructure.Contracts.Persistence;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Apartments;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Commons;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Invoices;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.InvoiceTypes;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Messages;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.Owners;
using SiteManagement.Infrastructure.Contracts.Persistence.Repositories.ProcessTypess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<SiteManagementContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

           
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceTypeRepository, InvoiceTypeRepository>();
            services.AddScoped<IProcessTypeRepository, ProcessTypeRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<ITokenHelper, JwtHelper>();


            return services;
        }
    }
}
