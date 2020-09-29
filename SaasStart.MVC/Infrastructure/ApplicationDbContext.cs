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
        /// Returns a whether the tenant database existed, and creates it if not.
        /// </summary>
        /// <param name="tenantInfo"></param>
        /// <param name="tenantInfoResult"></param>
        /// <returns></returns>
        public bool GenerateTenantDb(SaasTenantInfo tenantInfo, out SaasTenantInfo tenantInfoResult)
        {
            var conn = string.Format(_configuration.GetConnectionString("TenantConnection"),
                tenantInfo.Identifier);
            tenantInfo.ConnectionString = conn;
            
            var dbContext = new TenantDbContext(tenantInfo);
            
            var test = dbContext.Database.EnsureCreated();

            tenantInfoResult = tenantInfo;
            return test;
        }
    }
}