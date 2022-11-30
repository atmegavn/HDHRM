using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace HD.Profiles.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
