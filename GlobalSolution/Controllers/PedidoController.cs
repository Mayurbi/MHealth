using GlobalSolution.Areas.Identity.Data.Persistence.Repositorys;
using GlobalSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Listar()
        {
            IEnumerable<Pedido> pedidos = _pedidoRepository.GetAll();
            return View(pedidos);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            var pedidos = _pedidoRepository.GetAll();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(long id)
        {
            var pedido = _pedidoRepository.GetById(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public ActionResult<Pedido> Post(Pedido pedido)
        {
            _pedidoRepository.Add(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public ActionResult<Pedido> Put(long id, Pedido pedido)
        {
            var existingPedido = _pedidoRepository.GetById(id);
            if (existingPedido == null)
                return NotFound();

            existingPedido.FoiAceito = pedido.FoiAceito;
            existingPedido.NivelDor = pedido.NivelDor;
            existingPedido.LocalDor = pedido.LocalDor;
            existingPedido.TipoMedicacao = pedido.TipoMedicacao;
            existingPedido.Temperatura = pedido.Temperatura;
            existingPedido.Acompanhante = pedido.Acompanhante;


            _pedidoRepository.Update(existingPedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var pedido = _pedidoRepository.GetById(id);
            if (pedido == null)
                return NotFound();

            _pedidoRepository.Delete(pedido);
            return RedirectToAction("Listar");

            //  return NoContent();
        }
    }
}

