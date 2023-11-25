using Marketplace.Model;

namespace Marketplace.Repository.Interface
{

    public interface IVendedorRepositorio
    {
        Task<VendedorModel> Adicionar(VendedorModel Vendedor);
        Task<bool> Apagar(int id);
        Task<VendedorModel> Atualizar(VendedorModel Vendedor, int id);
        Task<VendedorModel> ObterPorId(int id);
        Task<List<VendedorModel>> ObterTodos();
    }
}
