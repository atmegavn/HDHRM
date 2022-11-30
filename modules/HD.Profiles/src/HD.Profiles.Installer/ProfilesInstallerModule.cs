﻿using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HD.Profiles;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ProfilesInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ProfilesInstallerModule>();
        });
    }
}
