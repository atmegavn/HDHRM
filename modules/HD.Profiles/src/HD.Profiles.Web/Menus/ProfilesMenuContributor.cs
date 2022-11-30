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
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(ProfilesMenus.Prefix, displayName: "Profiles", "~/Profiles", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
