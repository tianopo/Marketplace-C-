using Marketplace.Models.Model;

namespace Marketplace.Repository.Interface
{

    public interface IClienteRepositorio
    {
        Task<ClienteModel> Adicionar(ClienteModel cliente);
        Task<bool> Apagar(int id);
        Task<ClienteModel> Atualizar(ClienteModel cliente, int id);
        Task<ClienteModel> ObterPorId(int id);
        Task<List<ClienteModel>> ObterTodos();
    }
}
