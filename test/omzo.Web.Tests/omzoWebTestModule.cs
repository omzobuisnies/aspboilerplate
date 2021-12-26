using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using omzo.EntityFrameworkCore;
using omzo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace omzo.Web.Tests
{
    [DependsOn(
        typeof(omzoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class omzoWebTestModule : AbpModule
    {
        public omzoWebTestModule(omzoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(omzoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(omzoWebMvcModule).Assembly);
        }
    }
}