using Finbuckle.MultiTenant;
using Microsoft.Extensions.Hosting;
using SaasStart.Logic.Entities;
using SaasStart.MVC.Infrastructure;

namespace SaasStart.MVC.Migrations.SampleData
{
    public static class SampleTenants
    {
        /// <summary>
        /// Assumes the environment is development, which is determined in the Startup.cs call.
        /// </summary>
        /// <param name="dbContext"></param>
        public static void PopulateTenants(ApplicationDbContext dbContext)
        {
            var defaultTenant = new SaasTenantInfo
            {
                Id = "default-id",
                JwtAudience = "Default Audience",
                JwtAuthority = "Default Authority",
                Identifier = "default",
                Name = "Default Corporation"
            };
            defaultTenant.ConnectionString = dbContext.GenerateTenantDb(defaultTenant);
            
            var secondaryTenant = new SaasTenantInfo
            {
                Id = "secondary-id",
                JwtAudience = "Secondary Audience",
                JwtAuthority = "Secondary Authority",
                Identifier = "secondary",
                Name = "Secondary Incorporated"
            };
            secondaryTenant.ConnectionString = dbContext.GenerateTenantDb(secondaryTenant);
            
            dbContext.Add<ITenantInfo>(defaultTenant);
            dbContext.Add<ITenantInfo>(secondaryTenant);
            dbContext.SaveChanges();
        }
    }
}