using PizzaAPI.Data.DTOs;
using PizzaAPI.Data.Entities;

namespace PizzaAPI.Data.Interfaces
{
    public interface IOrderRepo
    {
        public Task PostFoodType(FoodTypeEntity foodTypeEntity);
        public Task<List<FoodTypeEntity>> GetFoodTypes();
        public Task PostFood(FoodEntity foodEntity);
        public Task<List<FoodEntity>> GetFoods();
        public Task PostOrder(OrderEntity orderEntity);
        public Task<List<OrderSummaryDTO>> GetOrders(int accountid);
        public Task<int> GetFoodPrice(int foodID);
    }
}
