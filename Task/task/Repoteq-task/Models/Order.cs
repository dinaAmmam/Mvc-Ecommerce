using System.ComponentModel.DataAnnotations;

namespace Repoteq_task.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? CustomerName { get; set; }

        
        public ICollection<OrderDetail> ?OrderDetails { get; set; }
    }
}
