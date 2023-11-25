using Marketplace.Data;
using Marketplace.Models.Model;
using Marketplace.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Models.Repository
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly MarketPlaceDBContext _dbContext;

        public ClienteRepositorio(MarketPlaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            await _dbContext.Cliente.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<ClienteModel> Atualizar(ClienteModel cliente, int id)
        {
            ClienteModel clientePorId = await ObterPorId(id);
            if (clientePorId == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrado no banco de dados.");
            }

            clientePorId.Nome = cliente.Nome;
            clientePorId.Senha = cliente.Senha;
            clientePorId.Endereco = cliente.Endereco;
            clientePorId.Email = cliente.Email;
            clientePorId.Cpf = cliente.Cpf;

            _dbContext.Cliente.Update(clientePorId);
            await _dbContext.SaveChangesAsync();

            return clientePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ClienteModel clientePorId = await ObterPorId(id);
            if (clientePorId == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Cliente.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ClienteModel> ObterPorId(int id)
        {
            return await _dbContext.Cliente.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ClienteModel>> ObterTodos()
        {
            return await _dbContext.Cliente.ToListAsync();
        }
    }
}
