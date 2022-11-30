using Localization.Resources.AbpUi;
using HD.Profiles.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace HD.Profiles;

[DependsOn(
    typeof(ProfilesApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ProfilesHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ProfilesHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ProfilesResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
