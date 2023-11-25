using Marketplace.Models.Model;

namespace Marketplace.Repository.Interface
{

    public interface ICarrinhoRepositorio
    {
        Task<CarrinhoModel> Adicionar(CarrinhoModel Carrinho);
        Task<bool> Apagar(int id);
        Task<CarrinhoModel> Atualizar(CarrinhoModel Carrinho, int id);
        Task<CarrinhoModel> ObterPorId(int id);
        Task<List<CarrinhoModel>> ObterTodos();
    }
}
