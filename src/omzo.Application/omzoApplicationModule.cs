using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using omzo.Authorization;

namespace omzo
{
    [DependsOn(
        typeof(omzoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class omzoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<omzoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(omzoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
