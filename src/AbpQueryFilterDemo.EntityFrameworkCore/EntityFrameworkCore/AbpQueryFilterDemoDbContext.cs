using Microsoft.EntityFrameworkCore;
using AbpQueryFilterDemo.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System;
using Microsoft.Extensions.Logging;

namespace AbpQueryFilterDemo.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See AbpQueryFilterDemoMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class AbpQueryFilterDemoDbContext : AbpDbContext<AbpQueryFilterDemoDbContext>, IAbpQueryFilterDemoDbContext
    {
        public DbSet<AppUser> Users { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside AbpQueryFilterDemoDbContextModelCreatingExtensions.ConfigureAbpQueryFilterDemo
         */
        public DbSet<Order> Orders { get; set; }
        protected virtual bool Active => GetActive();
        public ICurrentActive CurrentActive { get; set; }
        protected bool IsActiveFilterEnabled => DataFilter?.IsEnabled<IActive>() ?? false;
        private bool GetActive()
        {
            Logger.LogInformation($"Active:{CurrentActive.Active}");
            return CurrentActive.Active;
        }

        protected override bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType)
        {
            if (typeof(IActive).IsAssignableFrom(typeof(TEntity)))
                return true;
            return base.ShouldFilterEntity<TEntity>(entityType);
        }
        protected override Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
        {
            var expression = base.CreateFilterExpression<TEntity>();
            if (typeof(IActive).IsAssignableFrom(typeof(TEntity)))
            {
                Expression<Func<TEntity, bool>> dataSourcingFilter = e => !IsActiveFilterEnabled || EF.Property<bool>(e, "Active") == Active;
                expression = expression == null ? dataSourcingFilter : CombineExpressions(expression, dataSourcingFilter);
            }
            return expression;
        }

        public AbpQueryFilterDemoDbContext(DbContextOptions<AbpQueryFilterDemoDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the AbpQueryFilterDemoEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureAbpQueryFilterDemo method */

            builder.ConfigureAbpQueryFilterDemo();
        }
    }
}
