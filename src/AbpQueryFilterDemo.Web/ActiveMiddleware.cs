using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpQueryFilterDemo.Web
{
    public class ActiveMiddleware : IMiddleware, ITransientDependency
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.RequestServices.GetRequiredService<ICurrentActive>().Active = false;
            await next(context);
        }
    }
}
