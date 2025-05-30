using PizzaAPI.Data.DTOs;
using PizzaAPI.Data.Entities;

namespace PizzaAPI.Core.Interfaces
{
    public interface IOrderService
    {
        Task PostFoodType(FoodTypeEntity foodTypeEntity);
        Task<List<FoodTypeEntity>> GetFoodTypes();
        Task PostFood(FoodCreateDTO foodCreateDTO);
        Task<List<FoodEntity>> GetFoods();
        Task PostOrder(OrderDTO orderDTO, int accountID);
        Task<List<OrderSummaryDTO>> GetOrders(int accountid);
    }
}
