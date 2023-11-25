using Marketplace.Model;
using Marketplace.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace_Teste.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorRepositorio _VendedorRepositorio;
        public VendedorController(IVendedorRepositorio VendedorRepositorio)
        {
            _VendedorRepositorio = VendedorRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<VendedorModel>>> ObterTodos()
        {
            List<VendedorModel> Vendedor = await _VendedorRepositorio.ObterTodos();
            return Ok(Vendedor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendedorModel>> ObterPorId(int id)
        {
            VendedorModel Vendedor = await _VendedorRepositorio.ObterPorId(id);
            return Ok(Vendedor);
        }

        [HttpPost]
        public async Task<ActionResult<VendedorModel>> Cadastrar([FromBody] VendedorModel VendedorModel)
        {
            VendedorModel Vendedor = await _VendedorRepositorio.Adicionar(VendedorModel);

            return Ok(Vendedor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VendedorModel>> Atualizar([FromBody] VendedorModel VendedorModel, int id)
        {
            VendedorModel.Id = id;
            VendedorModel Vendedor = await _VendedorRepositorio.Atualizar(VendedorModel, id);

            return Ok(Vendedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VendedorModel>> Apagar(int id)
        {
            bool apagado = await _VendedorRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
