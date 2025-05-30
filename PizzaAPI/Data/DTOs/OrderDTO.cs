using PizzaAPI.Data.Entities;

namespace PizzaAPI.Data.DTOs
{
    public class OrderDTO
    {
        public ICollection<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
    }
}
