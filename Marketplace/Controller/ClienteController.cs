using Marketplace.Models.Model;
using Marketplace.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace_Teste.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> ObterTodos()
        {
            List<ClienteModel> cliente = await _clienteRepositorio.ObterTodos();
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> ObterPorId(int id)
        {
            ClienteModel cliente = await _clienteRepositorio.ObterPorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Cadastrar([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clienteRepositorio.Adicionar(clienteModel);

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> Atualizar([FromBody] ClienteModel clienteModel, int id)
        {
            clienteModel.Id = id;
            ClienteModel cliente = await _clienteRepositorio.Atualizar(clienteModel, id);

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModel>> Apagar(int id)
        {
            bool apagado = await _clienteRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
