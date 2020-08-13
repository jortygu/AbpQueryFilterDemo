using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace AbpQueryFilterDemo.Jobs
{
    [BackgroundJobName("OrderSyncJob")]
    public class OrderSyncJobArgs : ITransientDependency
    {
        public bool Active { get; set; }
    }
}
