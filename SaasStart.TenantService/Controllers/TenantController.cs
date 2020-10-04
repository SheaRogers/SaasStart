using System.Collections.Generic;
using System.Linq;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Mvc;
using SaasStart.Logic.Entities;
using SaasStart.Logic.Infrastructure;

namespace SaasStart.TenantService.Controllers
{
    public class TenantController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public TenantController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Returns all current tenants.
        /// </summary>
        /// <returns>IEnumerable<SaasTenantInfo></returns>
        [HttpGet]
        public IEnumerable<SaasTenantInfo> GetAllTenants()
        {
            return _dbContext.TenantInfo.AsEnumerable();
        }

        /// <summary>
        /// Returns a single tenant given an ID.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns>SaasTenantInfo</returns>
        [HttpGet]
        public SaasTenantInfo GetTenantById(string tenantId)
        {
            return _dbContext.TenantInfo.Find(tenantId);
        }
    }
}