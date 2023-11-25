using Marketplace.Models.Model;

namespace Marketplace.Repository.Interface
{

    public interface IProdutoRepositorio
    {
        Task<ProdutoModel> Adicionar(ProdutoModel Produto);
        Task<bool> Apagar(int id);
        Task<ProdutoModel> Atualizar(ProdutoModel Produto, int id);
        Task<ProdutoModel> ObterPorId(int id);
        Task<List<ProdutoModel>> ObterTodos();
    }
}
