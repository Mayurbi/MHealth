using GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Areas.Identity.Data.Persistence.Repositorys
{
    public interface IPedidoRepository
    {
        IEnumerable<Pedido> GetAll();
        Pedido GetById(long id);
        void Add(Pedido entity);
        void Update(Pedido entity);
        void Delete(Pedido entity);
        void DeleteAll();
    }

    public class PedidoRepository : IPedidoRepository
    {
        private readonly MySQLContext _dbContext;

        public PedidoRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Pedido> GetAll()
        {
            return _dbContext.Pedidos.ToList();
        }

        public Pedido GetById(long id)
        {
            return _dbContext.Pedidos.Find(id);
        }

        public void Add(Pedido pedido)
        {
            _dbContext.Pedidos.Add(pedido);
            _dbContext.SaveChanges();
        }

        public void Update(Pedido pedido)
        {
            _dbContext.Entry(pedido).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Pedido pedido)
        {
            _dbContext.Pedidos.Remove(pedido);
            _dbContext.SaveChanges();
        }

        public void DeleteAll()
        {
            _dbContext.Pedidos.RemoveRange(_dbContext.Pedidos);
            _dbContext.SaveChanges();
        }
    }
}
