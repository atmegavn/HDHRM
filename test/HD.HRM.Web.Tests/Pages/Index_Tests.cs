using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace HD.HRM.Pages;

public class Index_Tests : HRMWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
