using GlobalSolution.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using GlobalSolution.Models;
using Neo4jClient.DataAnnotations.Cypher.Functions;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using GlobalSolution.Areas.Identity.Data.DTOs;

namespace GlobalSolution.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private MySQLContext _context;
    private IMapper _mapper;


    public UsuarioController(MySQLContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarUsuario([FromBody] CriarUserDto usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);
    }

    [HttpGet]
    public IEnumerable<LerUserDto> GetAllUsers(
      [FromQuery] int skip = 0,
      [FromQuery] int take = 10,
      [FromQuery] string? email = null
    )
    {
        if (email != null)
        {
            return _mapper.Map<List<LerUserDto>>(_context.Usuarios.Where((usuario) => usuario.Email == email));
        }

        return _mapper.Map<List<LerUserDto>>(_context.Users.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetUsuarioById(string id)
    {
        Usuario? usuario = _context.Usuarios.FirstOrDefault((usuario) => usuario.Id == id);

        if (usuario == null)
        {
            return NotFound();
        }

        LerUserDto usuarioDto = _mapper.Map<LerUserDto>(usuario);

        return Ok(usuarioDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaUsuario(string id, [FromBody] AtualizarUserDto usuarioDto)
    {
        Usuario? usuario = _context.Usuarios.FirstOrDefault((usuario) => usuario.Id == id);

        if (usuario == null)
        {
            return NotFound();
        }

        _mapper.Map(usuarioDto, usuario);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchUsuario(string id, JsonPatchDocument<AtualizarUserDto> patch)
    {
        Usuario? usuario = _context.Usuarios.FirstOrDefault((usuario) => usuario.Id == id);

        if (usuario == null)
        {
            return NotFound();
        }

        AtualizarUserDto atualizaUsuario = _mapper.Map<AtualizarUserDto>(usuario);
        patch.ApplyTo(atualizaUsuario, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

        if (!TryValidateModel(atualizaUsuario))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(atualizaUsuario, usuario);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveUsuario(String id)
    {
        Usuario? usuario = _context.Usuarios.FirstOrDefault((usuario) => usuario.Id == id);

        if (usuario == null)
        {
            return NotFound();
        }

        _context.Remove(usuario);
        _context.SaveChanges();

        return NoContent();

    }
    [HttpGet("search")]
    public IEnumerable<LerUserDto> SearchUsers([FromQuery] string term)
    {
        if (string.IsNullOrEmpty(term))
        {
            return _mapper.Map<List<LerUserDto>>(_context.Usuarios);
        }


        return _mapper.Map<List<LerUserDto>>(_context.Usuarios.Where(usuario =>
            usuario.Id.Contains(term) || usuario.Email.Contains(term)));
    }

   // [HttpGet("dashboard")]
  //  public IActionResult Dashboard()
   // {

   //     var totalUsuarios = _context.Usuarios.Count();
   //     var usuariosAtivos = _context.Usuarios.Count(usuario => usuario.Ativo);

   //     var dashboardInfo = new
     //       TotalUsuarios = totalUsuarios,
     //       UsuariosAtivos = usuariosAtivos

      //  };

    //    return Ok(dashboardInfo);
   // }//
}