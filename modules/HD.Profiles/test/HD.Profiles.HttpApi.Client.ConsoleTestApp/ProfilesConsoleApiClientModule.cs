using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace HD.Profiles;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProfilesHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ProfilesConsoleApiClientModule : AbpModule
{

}
