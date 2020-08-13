using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpQueryFilterDemo.EntityFrameworkCore
{
    public class EfCoreOrderRepository : EfCoreRepository<IAbpQueryFilterDemoDbContext, Order, Guid>, IOrderRepository
    {
        public EfCoreOrderRepository(IDbContextProvider<IAbpQueryFilterDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
