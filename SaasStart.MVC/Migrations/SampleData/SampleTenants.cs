using Finbuckle.MultiTenant;
using SaasStart.Logic.Entities;
using SaasStart.Logic.Infrastructure;

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
            defaultTenant.TenantContent.Add("privacyPolicy", "Privacy is important to Default Corporation!");
            var defaultTest = dbContext.GenerateTenantDb(defaultTenant, out defaultTenant);

            if (!defaultTest)
            {
                dbContext.Add<ITenantInfo>(defaultTenant);
            }
            
            var secondaryTenant = new SaasTenantInfo
            {
                Id = "secondary-id",
                JwtAudience = "Secondary Audience",
                JwtAuthority = "Secondary Authority",
                Identifier = "secondary",
                Name = "Secondary Incorporated"
            };
            
            secondaryTenant.TenantContent.Add("privacyPolicy", "Privacy is important to Secondary Incorporated!");
            var secondaryTest = dbContext.GenerateTenantDb(secondaryTenant, out secondaryTenant);

            if (!secondaryTest)
            {
                dbContext.Add<ITenantInfo>(secondaryTenant);
            }
            
            dbContext.SaveChanges();
        }
    }
}