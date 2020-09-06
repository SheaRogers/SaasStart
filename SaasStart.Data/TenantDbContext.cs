using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using SaasStart.Logic.Entities;

namespace SaasStart.Data
{
    public class TenantDbContext : MultiTenantIdentityDbContext<ApplicationUser>
    {
        public TenantDbContext(SaasTenantInfo tenantInfo) : base(tenantInfo)
        {
        }
        
        public TenantDbContext(ITenantInfo tenantInfo, DbContextOptions<TenantDbContext> options)
            : base(tenantInfo, options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(TenantInfo.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}