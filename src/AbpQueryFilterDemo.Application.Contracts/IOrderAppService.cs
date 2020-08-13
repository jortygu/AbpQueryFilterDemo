using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpQueryFilterDemo
{
    public interface IOrderAppService : ICrudAppService<
            OrderDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateOrderDto,
            CreateUpdateOrderDto>
    {
    }
}
