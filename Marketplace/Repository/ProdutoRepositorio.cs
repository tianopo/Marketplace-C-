using Marketplace.Data;
using Marketplace.Models.Model;
using Marketplace.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Models.Repository
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly MarketPlaceDBContext _dbContext;

        public ProdutoRepositorio(MarketPlaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProdutoModel> Adicionar(ProdutoModel Produto)
        {
            await _dbContext.Produto.AddAsync(Produto);
            await _dbContext.SaveChangesAsync();

            return Produto;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel Produto, int id)
        {
            ProdutoModel ProdutoPorId = await ObterPorId(id);
            if (ProdutoPorId == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
            }

            ProdutoPorId.Descricao = Produto.Descricao;
            ProdutoPorId.Preco = Produto.Preco;
            ProdutoPorId.Imagem = Produto.Imagem;
            ProdutoPorId.Status = Produto.Status;
            ProdutoPorId.Vendedor = Produto.Vendedor;
            ProdutoPorId.Categoria = Produto.Categoria;

            _dbContext.Produto.Update(ProdutoPorId);
            await _dbContext.SaveChangesAsync();

            return ProdutoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoModel ProdutoPorId = await ObterPorId(id);
            if (ProdutoPorId == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Produto.Remove(ProdutoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProdutoModel> ObterPorId(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> ObterTodos()
        {
            return await _dbContext.Produto.ToListAsync();
        }
    }
}
