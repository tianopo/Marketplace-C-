using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marketplace.Pages
{
    public class CadastroModel : PageModel
    {
        private readonly ILogger<CadastroModel> _logger;

        public CadastroModel(ILogger<CadastroModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
