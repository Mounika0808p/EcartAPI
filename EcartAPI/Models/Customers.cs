using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EcartAPI.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; } 
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
