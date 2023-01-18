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
        context.Menu.AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, displayName: "Profiles", "~/Profiles", icon: "fa fa-globe"));
        context.Menu.AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, localizer["Human Resource Management"], icon: "mdi mdi-home")
           .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, localizer["Employees"], url: "/Employees", icon: "mdi mdi-account"))
           .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, localizer["Profiles"], url: "/Profiles", icon: "mdi mdi-file-account"))
           .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, localizer["Organizations"], url: "/Organizations", icon: "mdi mdi-office-building"))
           .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, localizer["Job Title"], url: "/JobTitles", icon: "mdi mdi-card-account-details"))
           .AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, localizer["Jobs"], url: "/Jobs", icon: "mdi mdi-account-tie"))
       );
        return Task.CompletedTask;
    }
}
