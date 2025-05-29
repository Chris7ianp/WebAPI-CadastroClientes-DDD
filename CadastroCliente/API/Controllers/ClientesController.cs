using CadastroCliente.Application.DTOs;
using CadastroCliente.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;
        public ClientesController(ClienteService service) => _service = service;

        [HttpGet] public IActionResult Get() => Ok(_service.ObterTodos());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var cliente = _service.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound(new { codigo = "404", mensagem = "Cliente não encontrado!" });
            }
            else
            {
                return Ok(cliente);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteDto dto)
        {
            var (clienteCriado, erro) = _service.Criar(dto);

            if(erro != null)
            {
                return BadRequest(erro);
            }

            return CreatedAtAction(nameof(Get), new { id = clienteCriado!.Id }, clienteCriado); // Retorna o novo recurso com a URL.
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ClienteDto dto)
        {
            var erro = _service.Atualizar(id, dto);

            if (erro == null)
            {
                return Ok(new { codigo = "200", mensagem = "Cliente atualizado com sucesso!" });
            }
            else
            {
                return NotFound(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var remover = _service.Remover(id);

            if (remover)
            {
                return Ok(new { codigo = "200", mensagem = "Cliente excluido com sucesso!" });
            }
            else
            {
                return NotFound(new { codigo = "404", mensagem = "Algo deu errado." });
            }
        }
    }
}
