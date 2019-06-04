using Abp.MultiTenancy;
using MyProject.Authorization.Users;

namespace MyProject.MultiTenancy
{
    public class Tenant : AbpTenant<UserLogin>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
