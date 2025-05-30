using System.ComponentModel.DataAnnotations;

namespace PizzaAPI.Data.Entities
{
    public class OrderItemEntity
    {
        [Key]
        public int OrderItemID { get; set; }

        public int OrderID { get; set; }
        public OrderEntity Order { get; set; }

        public int FoodID { get; set; }
        public FoodEntity Food { get; set; }

        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
