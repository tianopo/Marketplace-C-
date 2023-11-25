using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marketplace.Pages
{
    public class ProdutoModel : PageModel
    {
        private readonly ILogger<ProdutoModel> _logger;

        public ProdutoModel(ILogger<ProdutoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
