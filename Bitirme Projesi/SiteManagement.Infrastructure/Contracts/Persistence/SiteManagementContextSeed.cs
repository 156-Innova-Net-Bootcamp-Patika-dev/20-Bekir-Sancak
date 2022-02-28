using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiteManagement.Domain.Entities.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Infrastructure.Contracts.Persistence
{
    public class SiteManagementContextSeed
    {
        public static async Task SeedAsync(SiteManagementContext siteManagementContext, ILogger<SiteManagementContextSeed> logger)
        {
            if (!siteManagementContext.Roles.Any())
            {
                siteManagementContext.Roles.AddRange(new List<Role>
                {
                    new Role{ Name="Admin"},
                    new Role{ Name="Tenant"},
                    new Role{ Name="HomeOwner "}

                });
                await siteManagementContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(SiteManagementContext).Name);
            }

           
        }
    }
}
