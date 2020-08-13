using System.Threading.Tasks;

namespace AbpQueryFilterDemo.Web.Pages
{
    public class IndexModel : AbpQueryFilterDemoPageModel
    {
        private readonly IOrderAppService _orderAppService;
        
        public IndexModel(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        public async Task OnGet()
        {
            var list = await _orderAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto());
        }
    }
}