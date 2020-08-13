using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace AbpQueryFilterDemo.Jobs
{
    public class OrderSyncJob : AsyncBackgroundJob<OrderSyncJobArgs>, ITransientDependency
    {
        private readonly IOrderRepository _orderRepository;
        public IServiceProvider ServiceProvider { get; set; }
        public OrderSyncJob(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public override async Task ExecuteAsync(OrderSyncJobArgs args)
        {
            ServiceProvider.GetRequiredService<ICurrentActive>().Active = args.Active;
            var list = await _orderRepository.GetListAsync();
        }
    }
}
