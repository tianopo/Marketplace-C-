using Marketplace.Models.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marketplace.Pages.Shared
{
    public class IndexModel : PageModel
    {
        public List<ProdutoModel> Produtos { get; set; }

        public void OnGet()
        {
            Produtos = new List<ProdutoModel>
            {
                new ProdutoModel { Id = 1, Descricao = "Produto 1", Preco = 19.99m, Imagem = "/images/product1.jpg", Status = true },
                new ProdutoModel { Id = 2, Descricao = "Produto 2", Preco = 29.99m, Imagem = "/images/product2.jpg", Status = true },
            };
        }
    }
}
