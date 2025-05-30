namespace PizzaAPI.Data.DTOs
{
    public class OrderSummaryDTO
    {
        public int OrderID { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemSummaryDTO> Items { get; set; }
            = new List<OrderItemSummaryDTO>();
    }
}
