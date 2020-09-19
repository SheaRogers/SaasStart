using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SaasStart.Logic.Entities;

namespace SaasStart.Data.Factories
{
    /// <summary>
    ///     Allows EntityFramework to perform migrations with Finbuckle.MultiTenant.
    /// </summary>
    public class DesignTimeFactory : IDesignTimeDbContextFactory<TenantDbContext>
    {
        public TenantDbContext CreateDbContext(string[] args)
        {
            // To prep each database uncomment the corresponding line below.
            var tenantInfo = new SaasTenantInfo {ConnectionString = "Data Source=Data/SharedIdentity.db"};
            // var tenantInfo = new TenantInfo{ ConnectionString = "Data Source=Data/InitechIdentity.db" };
            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();

            return new TenantDbContext(tenantInfo, optionsBuilder.Options);
        }
    }
}