using System.Collections.Generic;
using Finbuckle.MultiTenant;

namespace SaasStart.Logic.Entities
{
    /// <summary>
    /// Contains extra information specific to a tenant.
    /// </summary>
    public class SaasTenantInfo : TenantInfo
    {
        public string JwtAuthority { get; set; }
        public string JwtAudience { get; set; }

        public Dictionary<string, string> TenantContent;

        public SaasTenantInfo()
        {
            TenantContent = new Dictionary<string, string>();
        }
    }
}