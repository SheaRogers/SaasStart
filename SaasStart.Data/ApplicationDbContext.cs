using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using SaasStart.Logic.Entities;

namespace SaasStart.Data
{
    public class ApplicationDbContext : EFCoreStoreDbContext<SaasTenantInfo>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}