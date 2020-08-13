using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace AbpQueryFilterDemo.EntityFrameworkCore
{
    public static class AbpQueryFilterDemoDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpQueryFilterDemo(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Order>(b => {
                b.ToTable(AbpQueryFilterDemoConsts.DbTablePrefix + "Order", AbpQueryFilterDemoConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.OrderNo).HasMaxLength(40).IsRequired();
            });
        }
    }
}