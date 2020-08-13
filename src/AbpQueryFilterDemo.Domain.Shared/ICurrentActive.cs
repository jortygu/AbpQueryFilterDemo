using Volo.Abp.DependencyInjection;

namespace AbpQueryFilterDemo
{
    public interface ICurrentActive : IScopedDependency
    {
        bool Active { get; set; }
    }
}
