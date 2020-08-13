using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AbpQueryFilterDemo.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public interface IAbpQueryFilterDemoDbContext : IEfCoreDbContext
    {
        DbSet<Order> Orders { get; set; }
    }
}
