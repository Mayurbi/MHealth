
using GlobalSolution.Controllers;
using GlobalSolution.Models.Usuario;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Areas.Identity.Data.Persistence.Repositorys
{
    public interface IUsuarioRepository
    {

        IEnumerable<UsuarioController> GetAll();
        UsuarioController GetById(long id);
        void Add(UsuarioController entity);
        void Update(UsuarioController entity);
        void Delete(UsuarioController entity);
        void DeleteAll();
        void Add(Models.Usuario usuario);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MySQLContext _dbContext;

        public UsuarioRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UsuarioController> GetAll()
        {
            return (IEnumerable<UsuarioController>)_dbContext.Usuarios.ToList();
        }

        public UsuarioController GetById(long id)
        {
            return _dbContext.Usuarios.Find(id);
        }

        public void Add(UsuarioController usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
        }

        public void Update(UsuarioController usuario)
        {
            _dbContext.Entry(usuario).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(UsuarioController usuario)
        {
            _dbContext.Usuarios.Remove(usuario);
            _dbContext.SaveChanges();
        }

        public void DeleteAll()
        {

            _dbContext.Usuarios.RemoveRange(_dbContext.Usuarios);
            _dbContext.SaveChanges();
        }

        public void Add(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
