using Marketplace.Data;
using Marketplace.Model;
using Marketplace.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Models.Repository
{
    public class VendedorRepositorio : IVendedorRepositorio
    {
        private readonly MarketPlaceDBContext _dbContext;

        public VendedorRepositorio(MarketPlaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<VendedorModel> Adicionar(VendedorModel Vendedor)
        {
            await _dbContext.Vendedor.AddAsync(Vendedor);
            await _dbContext.SaveChangesAsync();

            return Vendedor;
        }

        public async Task<VendedorModel> Atualizar(VendedorModel Vendedor, int id)
        {
            VendedorModel VendedorPorId = await ObterPorId(id);
            if (VendedorPorId == null)
            {
                throw new Exception($"Vendedor para o ID: {id} não foi encontrado no banco de dados.");
            }

            VendedorPorId.RazaoSocial = Vendedor.RazaoSocial;
            VendedorPorId.NomeFantasia = Vendedor.NomeFantasia;
            VendedorPorId.Email = Vendedor.Email;
            VendedorPorId.Senha = Vendedor.Senha;
            VendedorPorId.Cnpj = Vendedor.Cnpj;
            VendedorPorId.Comissao = Vendedor.Comissao;
            VendedorPorId.Endereco = Vendedor.Endereco;

            _dbContext.Vendedor.Update(VendedorPorId);
            await _dbContext.SaveChangesAsync();

            return VendedorPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            VendedorModel VendedorPorId = await ObterPorId(id);
            if (VendedorPorId == null)
            {
                throw new Exception($"Vendedor para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Vendedor.Remove(VendedorPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<VendedorModel> ObterPorId(int id)
        {
            return await _dbContext.Vendedor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<VendedorModel>> ObterTodos()
        {
            return await _dbContext.Vendedor.ToListAsync();
        }
    }
}
