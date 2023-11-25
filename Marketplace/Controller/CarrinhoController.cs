using Marketplace.Models.Model;
using Marketplace.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace_Teste.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoRepositorio _CarrinhoRepositorio;
        public CarrinhoController(ICarrinhoRepositorio CarrinhoRepositorio)
        {
            _CarrinhoRepositorio = CarrinhoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<CarrinhoModel>>> ObterTodos()
        {
            List<CarrinhoModel> Carrinho = await _CarrinhoRepositorio.ObterTodos();
            return Ok(Carrinho);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarrinhoModel>> ObterPorId(int id)
        {
            CarrinhoModel Carrinho = await _CarrinhoRepositorio.ObterPorId(id);
            return Ok(Carrinho);
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoModel>> Cadastrar([FromBody] CarrinhoModel CarrinhoModel)
        {
            CarrinhoModel Carrinho = await _CarrinhoRepositorio.Adicionar(CarrinhoModel);

            return Ok(Carrinho);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarrinhoModel>> Atualizar([FromBody] CarrinhoModel CarrinhoModel, int id)
        {
            CarrinhoModel.Id = id;
            CarrinhoModel Carrinho = await _CarrinhoRepositorio.Atualizar(CarrinhoModel, id);

            return Ok(Carrinho);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CarrinhoModel>> Apagar(int id)
        {
            bool apagado = await _CarrinhoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
