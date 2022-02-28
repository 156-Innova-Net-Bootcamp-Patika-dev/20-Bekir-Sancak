
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Domain.Entities.Apartmens;
using SiteManagement.Domain.Entities.Authentications;
using SiteManagement.Domain.Entities.Commons;
using SiteManagement.Domain.Entities.Invoices;
using SiteManagement.Domain.Entities.InvoiceTypes;
using SiteManagement.Domain.Entities.Messages;
using SiteManagement.Domain.Entities.Owners;
using SiteManagement.Domain.Entities.ProcessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Infrastructure.Contracts.Persistence
{
    public class SiteManagementContext: IdentityDbContext<User,Role,int>
    {
        public SiteManagementContext(DbContextOptions<SiteManagementContext> options) : base(options)
        {

        }


      
        public DbSet<Apartment>  Apartments { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceType> InvoiceTypes { get; set; }

        public DbSet<ProcessType> ProcessTypes { get; set; }


        public DbSet<Message> Messages { get; set; }



    }
}
