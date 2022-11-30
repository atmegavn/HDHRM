using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HD.Profiles;

[DependsOn(
    typeof(ProfilesApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ProfilesHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ProfilesApplicationContractsModule).Assembly,
            ProfilesRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ProfilesHttpApiClientModule>();
        });

    }
}
