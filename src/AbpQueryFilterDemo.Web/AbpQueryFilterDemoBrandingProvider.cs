using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace AbpQueryFilterDemo.Web
{
    [Dependency(ReplaceServices = true)]
    public class AbpQueryFilterDemoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpQueryFilterDemo";
    }
}
