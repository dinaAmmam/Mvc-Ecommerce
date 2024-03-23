using Repoteq_task.Models;

namespace Repoteq_task.Repository
{
    public interface IProductRepo
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
    public class ProductRepo:IProductRepo
    {
        TaskContext db = new TaskContext();

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }
        public Product GetById(int id)
        {
            return db.Products.SingleOrDefault(a => a.ProductId == id);
        }
        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public void Update(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var prod = GetById(id);
            //for not deleting from db 
            prod.Status = false;
            db.Products.Remove(prod);
            db.SaveChanges();
        }
    }
}
