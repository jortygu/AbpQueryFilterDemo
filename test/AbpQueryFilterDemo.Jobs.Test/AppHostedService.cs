using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;

namespace AbpQueryFilterDemo.Jobs.Test
{
    public class AppHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<AppModule>(options =>
            {
                options.UseAutofac(); //Autofac integration
            }))
            {
                application.Initialize();

                //Resolve a service and use it

                Console.WriteLine(application.ServiceProvider.GetRequiredService<ICurrentActive>().Active);
                var orderSyncJob = application.ServiceProvider.GetService<OrderSyncJob>();
                await orderSyncJob.ExecuteAsync(new OrderSyncJobArgs() { Active = false });
                Console.WriteLine(application.ServiceProvider.GetRequiredService<ICurrentActive>().Active);
                application.Shutdown();
            }

            //return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}