using System.Threading.Tasks;
using HD.HRM.Localization;
using HD.HRM.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace HD.HRM.Web.Menus;

public class HRMMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<HRMResource>();

        //context.Menu.Items.Insert(
        //    0,
        //    new ApplicationMenuItem(
        //        HRMMenus.Home,
        //        l["Menu:Home"],
        //        "~/",
        //        icon: "fas fa-home",
        //        order: 0
        //    )
        //);

        context.Menu.AddItem(new ApplicationMenuItem(HRMMenus.Strategic, displayName: "Employees Strategy", icon: "fa fa-globe", order: 1)
             .AddItem(new ApplicationMenuItem(HRMMenus.Strategic, "Organizational", url: "/Organizations", icon: "mdi mdi-office-building"))
             //.AddItem(new ApplicationMenuItem(HRMMenus.Strategic, "Competency dictionary", url: "/Competency", icon: "mdi mdi-account"))
             .AddItem(new ApplicationMenuItem(HRMMenus.Strategic, "Job Title", url: "/JobTitles", icon: "mdi mdi-card-account-details"))
             .AddItem(new ApplicationMenuItem(HRMMenus.Strategic, "Job Position", url: "/Jobs", icon: "mdi mdi-account-tie"))
        );

        context.Menu.AddItem(new ApplicationMenuItem(HRMMenus.Danhmuc, "Category", icon: "mdi mdi-book")
            .AddItem(new ApplicationMenuItem(HRMMenus.Hanhchinh, displayName: "Administrative Unit", icon: "mdi mdi-bookmark")
                .AddItem(new ApplicationMenuItem(HRMMenus.Hanhchinh, displayName: "Country", url: "/Nationals", icon: "mdi mdi-book-marker"))
                .AddItem(new ApplicationMenuItem(HRMMenus.Hanhchinh, displayName: "Province", url: "/Provide", icon: "mdi mdi-book-marker"))
                .AddItem(new ApplicationMenuItem(HRMMenus.Hanhchinh, displayName: "District", url: "/District", icon: "mdi mdi-book-marker"))
                .AddItem(new ApplicationMenuItem(HRMMenus.Hanhchinh, displayName: "Religion", url: "/District", icon: "mdi mdi-book-check"))
                .AddItem(new ApplicationMenuItem(HRMMenus.Hanhchinh, displayName: "Ethnicity", url: "/District", icon: "mdi mdi-book-check"))
                )
            //.AddItem(new ApplicationMenuItem(HRMMenus.Giaoduc, displayName: "Education", url: "/Education", icon: "mdi mdi-bookmark"))
        );


        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
