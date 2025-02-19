using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcartAPI.Models
{
    public class Orders
    {

        [Key]
        public int OrderId { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime OrderDate { get; set; }
      


        [ForeignKey("CustomerId")]
        public Customers? customers { get; set; }

        [ForeignKey("ProductId")]

        public Product? Product { get; set; }
        
           
        



    }
}
