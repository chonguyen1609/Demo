using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using MyProject.Authorization.Roles;

namespace MyProject.Authorization.Users
{
    public class UserManager : AbpUserManager<Role, UserLogin>
    {
        public UserManager(
            RoleManager roleManager,
            UserStore store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<UserLogin> passwordHasher, 
            IEnumerable<IUserValidator<UserLogin>> userValidators, 
            IEnumerable<IPasswordValidator<UserLogin>> passwordValidators,
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<UserLogin>> logger, 
            IPermissionManager permissionManager, 
            IUnitOfWorkManager unitOfWorkManager, 
            ICacheManager cacheManager, 
            IRepository<OrganizationUnit, long> organizationUnitRepository, 
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, 
            IOrganizationUnitSettings organizationUnitSettings, 
            ISettingManager settingManager)
            : base(
                roleManager, 
                store, 
                optionsAccessor, 
                passwordHasher, 
                userValidators, 
                passwordValidators, 
                keyNormalizer, 
                errors, 
                services, 
                logger, 
                permissionManager, 
                unitOfWorkManager, 
                cacheManager,
                organizationUnitRepository, 
                userOrganizationUnitRepository, 
                organizationUnitSettings, 
                settingManager)
        {
        }
    }
}
