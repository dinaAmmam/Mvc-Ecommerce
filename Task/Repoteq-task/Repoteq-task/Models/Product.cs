using System.ComponentModel.DataAnnotations;

namespace Repoteq_task.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ?Name { get; set; }
        public string ?Image {  get; set; }

        public int ?Price { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public bool Status { get; set; } = true;


        public ICollection<OrderDetail> ?OrderDetails { get; set; }


    }
}
