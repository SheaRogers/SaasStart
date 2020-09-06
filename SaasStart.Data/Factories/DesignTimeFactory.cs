using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SaasStart.Data.Factories
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<TenantDbContext>
    {
        public TenantDbContext CreateDbContext(string[] args)
        {
            // To prep each database uncomment the corresponding line below.
            var tenantInfo = new TenantInfo{ ConnectionString = "Data Source=Data/SharedIdentity.db" };
            // var tenantInfo = new TenantInfo{ ConnectionString = "Data Source=Data/InitechIdentity.db" };
            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();

            return new TenantDbContext(tenantInfo, optionsBuilder.Options);
        }
    }
}