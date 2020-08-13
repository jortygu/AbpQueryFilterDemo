using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AbpQueryFilterDemo.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(AbpQueryFilterDemoHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AbpQueryFilterDemoConsoleApiClientModule : AbpModule
    {
        
    }
}
