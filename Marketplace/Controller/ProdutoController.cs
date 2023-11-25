using Marketplace.Models.Model;
using Marketplace.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace_Teste.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _ProdutoRepositorio;
        public ProdutoController(IProdutoRepositorio ProdutoRepositorio)
        {
            _ProdutoRepositorio = ProdutoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> ObterTodos()
        {
            List<ProdutoModel> Produto = await _ProdutoRepositorio.ObterTodos();
            return Ok(Produto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> ObterPorId(int id)
        {
            ProdutoModel Produto = await _ProdutoRepositorio.ObterPorId(id);
            return Ok(Produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel ProdutoModel)
        {
            ProdutoModel Produto = await _ProdutoRepositorio.Adicionar(ProdutoModel);

            return Ok(Produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel ProdutoModel, int id)
        {
            ProdutoModel.Id = id;
            ProdutoModel Produto = await _ProdutoRepositorio.Atualizar(ProdutoModel, id);

            return Ok(Produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Apagar(int id)
        {
            bool apagado = await _ProdutoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
