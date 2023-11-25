using Marketplace.Enums;

namespace Marketplace.Models.Model
{
    public class CarrinhoModel
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public ClienteModel Cliente { get; set; }
        public List<ProdutoModel> Produto { get; set; }
    }
}
