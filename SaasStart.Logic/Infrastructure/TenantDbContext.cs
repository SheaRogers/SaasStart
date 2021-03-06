﻿using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using SaasStart.Logic.Entities;

namespace SaasStart.Logic.Infrastructure
{
    /// <summary>
    /// Provides access to each tenant database.
    /// </summary>
    public class TenantDbContext : MultiTenantIdentityDbContext
    {
        public TenantDbContext(SaasTenantInfo tenantInfo) : base(tenantInfo)
        {
        }

        public TenantDbContext(SaasTenantInfo tenantInfo, DbContextOptions<TenantDbContext> options)
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