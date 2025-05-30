using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaAPI.Data.Entities
{
    public class OrderEntity
    {
            [Key]
            public int OrderID { get; set; }

            public int AccountID { get; set; }

            public AccountEntity Account { get; set; }

            public DateTime OrderDate { get; set; } = DateTime.UtcNow;

            [NotMapped]
            public decimal TotalPrice => Items.Sum(i => i.UnitPrice * i.Quantity);
            
            public ICollection<OrderItemEntity> Items { get; set; } = new List<OrderItemEntity>();
    }
}
