using System;
using Volo.Abp.Application.Dtos;

namespace AbpQueryFilterDemo
{
    public class OrderDto: FullAuditedEntityDto<Guid>
    {
        public string OrderNo { get; set; }

        public bool Active { get; set; }
    }
}
