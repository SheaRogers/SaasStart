using System;
using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SaasStart.Logic.Entities;

namespace SaasStart.MVC.Infrastructure
{
    /// <summary>
    /// Stores information for cross tenant functionality.
    /// </summary>
    public class ApplicationDbContext : EFCoreStoreDbContext<SaasTenantInfo>
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Returns a valid tenant context given a tenant name. Only needed on initial tenant generation.
        /// </summary>
        /// <param name="tenantInfo"></param>
        /// <returns></returns>
        public string GenerateTenantDb(SaasTenantInfo tenantInfo)
        {
            var conn = string.Format(_configuration.GetConnectionString("TenantConnection"),
                tenantInfo.Identifier + Guid.NewGuid().ToString().Substring(0, 5));
            tenantInfo.ConnectionString = conn;
            
            var dbContext = new TenantDbContext(tenantInfo);
            
            dbContext.Database.EnsureCreated();

            return conn;
        }
    }
}