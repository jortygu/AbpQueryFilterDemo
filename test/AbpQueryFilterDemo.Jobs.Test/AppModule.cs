using AbpQueryFilterDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpQueryFilterDemo.Jobs.Test
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpQueryFilterDemoEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpQueryFilterDemoApplicationContractsModule),
        typeof(JobModule)
        )]
    public class AppModule : AbpModule
    {

    }
}
