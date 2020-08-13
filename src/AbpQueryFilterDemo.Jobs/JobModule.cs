using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpQueryFilterDemo.Jobs
{
    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class JobModule : AbpModule
    {
    }
}
