using Marketplace.Model;

namespace Marketplace.Models.Model
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public bool Status { get; set; }
        public VendedorModel Vendedor { get; set; }
        public CategoriaModel Categoria { get; set; }
    }
}
