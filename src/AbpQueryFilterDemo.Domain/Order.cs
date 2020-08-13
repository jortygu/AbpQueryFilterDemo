using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpQueryFilterDemo
{
    public class Order : FullAuditedAggregateRoot<Guid>, IActive
    {
        public virtual string OrderNo { get; protected set; }

        public virtual bool Active { get; protected set; }

        protected Order() { }

        public Order(Guid id, string orderNo, bool active)
        {
            Id = id;
            OrderNo = orderNo;
            Active = active;
        }
    }
}
