using AutoMapper;
using GlobalSolution.Areas.Identity.Data.DTOs;
using GlobalSolution.Areas.Identity.Data;
using GlobalSolution.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private MySQLContext _context;
        private IMapper _mapper;


        public PedidosController(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaPedido([FromBody] CriarPedidoDto pedidoDto)
        {
            Pedido pedido = _mapper.Map<Pedido>(pedidoDto);

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPedidoById), new { id = pedido.Id }, pedido);
        }
        public IEnumerable<LerPedidoDto> GetAllUsers(
           [FromQuery] int skip = 0,
           [FromQuery] int take = 10,
           [FromQuery] string? nome = null
         )
        {
            if (nome != null)
            {
                return _mapper.Map<List<LerPedidoDto>>(_context.Pedidos.Where((pedido) => pedido.Nome == nome));
            }

            return _mapper.Map<List<LerPedidoDto>>(_context.Pedidos.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetPedidoById(string id)
        {
            Pedido? pedido = _context.Pedidos.FirstOrDefault((pedido) => pedido.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            LerPedidoDto pedidoDto = _mapper.Map<LerPedidoDto>(pedido);
            return Ok(pedidoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPedido(string id, [FromBody] AtualizarPedidoDto pedidoDto)
        {
            Pedido? pedido = _context.Pedidos.FirstOrDefault((pedido) => pedido.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            _mapper.Map(pedidoDto, pedido);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchPedido(string id, JsonPatchDocument<AtualizarPedidoDto> patch)
        {
            Pedido? pedido = _context.Pedidos.FirstOrDefault((pedido) => pedido.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            AtualizarPedidoDto atualizaPedido = _mapper.Map<AtualizarPedidoDto>(pedido);
            patch.ApplyTo(atualizaPedido, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

            if (!TryValidateModel(atualizaPedido))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(atualizaPedido, pedido);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePedido(String id)
        {
            Pedido? pedido = _context.Pedidos.FirstOrDefault((pedido) => pedido.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            _context.Remove(pedido);
            _context.SaveChanges();

            return NoContent();
        }

    }
}