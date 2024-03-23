using Microsoft.EntityFrameworkCore;
using Repoteq_task.Models;

namespace Repoteq_task.Repository
{
    public interface IOrderRepo
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
    }
    public class OrderRepo:IOrderRepo
    {

        TaskContext db = new TaskContext();

        public List<Order> GetAll()
        {
            return db.Orders.Include(s => s.OrderDetails).ThenInclude(a=>a.Product).ToList();
        }
        public Order GetById(int id)
        {
            return db.Orders.Include(s => s.OrderDetails).ThenInclude(a => a.Product).SingleOrDefault(a => a.OrderId == id);
        }
        public void Add(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public void Update(Order order)
        {
            db.Orders.Update(order);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var ord = GetById(id);
            db.Orders.Remove(ord);
            db.SaveChanges();
        }
    }
}
