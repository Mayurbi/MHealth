using GlobalSolution.Areas.Identity.Data.Persistence.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient.DataAnnotations.Cypher.Functions;

namespace GlobalSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Listar()
        {
            IEnumerable<Models.Usuario> usuarios = (IEnumerable<Models.Usuario>)_usuarioRepository.GetAll();
            return View(usuarios);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Models.Usuario>> Get()
        {
            var usuarios = _usuarioRepository.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Usuario> Get(long id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult<Models.Usuario> Post(Models.Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult<Models.Usuario> Put(long id, Models.Usuario usuario)
        {
            var existingUsuario = _usuarioRepository.GetById(id);
            if (existingUsuario == null)
                return NotFound();

            _usuarioRepository.Update(existingUsuario);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(long id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
                return NotFound();

            _usuarioRepository.Delete(usuario);
            return RedirectToAction("Listar");

            //  return NoContent();
        }
    }
}
