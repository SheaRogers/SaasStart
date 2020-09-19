using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using SaasStart.Logic.Entities;

namespace SaasStart.Data
{
    /// <summary>
    /// Stores information for cross tenant functionality.
    /// </summary>
    public class ApplicationDbContext : EFCoreStoreDbContext<SaasTenantInfo>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}