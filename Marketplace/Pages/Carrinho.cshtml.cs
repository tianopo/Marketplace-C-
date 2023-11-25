using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marketplace.Pages
{
    public class CarrinhoModel : PageModel
    {
        private readonly ILogger<CarrinhoModel> _logger;

        public CarrinhoModel(ILogger<CarrinhoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
