using System;
using Volo.Abp.Domain.Repositories;

namespace AbpQueryFilterDemo
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
    }
}
