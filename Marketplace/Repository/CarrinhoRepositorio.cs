using Marketplace.Data;
using Marketplace.Models.Model;
using Marketplace.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Models.Repository
{
    public class CarrinhoRepositorio : ICarrinhoRepositorio
    {
        private readonly MarketPlaceDBContext _dbContext;

        public CarrinhoRepositorio(MarketPlaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CarrinhoModel> Adicionar(CarrinhoModel Carrinho)
        {
            await _dbContext.Carrinho.AddAsync(Carrinho);
            await _dbContext.SaveChangesAsync();

            return Carrinho;
        }

        public async Task<CarrinhoModel> Atualizar(CarrinhoModel Carrinho, int id)
        {
            CarrinhoModel CarrinhoPorId = await ObterPorId(id);
            if (CarrinhoPorId == null)
            {
                throw new Exception($"Carrinho para o ID: {id} não foi encontrado no banco de dados.");
            }

            CarrinhoPorId.DataPedido = Carrinho.DataPedido;
            CarrinhoPorId.ValorTotal = Carrinho.ValorTotal;
            CarrinhoPorId.StatusPedido = Carrinho.StatusPedido;
            CarrinhoPorId.Cliente = Carrinho.Cliente;
            CarrinhoPorId.Produto = Carrinho.Produto;

            _dbContext.Carrinho.Update(CarrinhoPorId);
            await _dbContext.SaveChangesAsync();

            return CarrinhoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            CarrinhoModel CarrinhoPorId = await ObterPorId(id);
            if (CarrinhoPorId == null)
            {
                throw new Exception($"Carrinho para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Carrinho.Remove(CarrinhoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CarrinhoModel> ObterPorId(int id)
        {
            return await _dbContext.Carrinho.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CarrinhoModel>> ObterTodos()
        {
            return await _dbContext.Carrinho.ToListAsync();
        }
    }
}
