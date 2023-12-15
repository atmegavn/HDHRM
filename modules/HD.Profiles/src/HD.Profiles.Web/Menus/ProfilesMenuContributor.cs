using HD.Profiles.Localization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace HD.Profiles.Web.Menus;

public class ProfilesMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var localizer = context.GetLocalizer<ProfilesResource>();
        //Add main menu items.
        //context.Menu.AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, displayName: "Chiến lược nhân sự", icon: "fa fa-globe")
        //     .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Từ điển năng lực", url: "/Competency", icon: "mdi mdi-account"))
        //     .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Cơ cấu tổ chức", url: "/Organizations", icon: "mdi mdi-office-building"))
        //     .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Chức danh công việc", url: "/JobTitles", icon: "mdi mdi-card-account-details"))
        //     .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Vị trí việc làm", url: "/Jobs", icon: "mdi mdi-account-tie"))
        //);

        context.Menu.AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, displayName: "Hồ sơ nhân viên", icon: "mdi mdi-home", order: 2)
           .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, localizer["Employees"], url: "/Employees", icon: "mdi mdi-account"))
           .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, localizer["Profiles"], url: "/Profiles", icon: "mdi mdi-file-account"))
        );

        //context.Menu.AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Danh mục", icon: "mdi mdi-home")
        //   .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Đơn vị hành chính", icon: "mdi mdi-account")
        //        .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Quốc gia", url: "/Nationals", icon: "mdi mdi-account"))
        //        .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Tỉnh", url: "/Provide", icon: "mdi mdi-account"))
        //        .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Huyện", url: "/District", icon: "mdi mdi-account")))
        //   .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, "Đơn vị giáo dục", url: "/Education", icon: "mdi mdi-file-account"))
        //);
        return Task.CompletedTask;
    }
}
