using Microsoft.Identity.Client;
using PizzaAPI.Core.Interfaces;
using PizzaAPI.Data.DTOs;
using PizzaAPI.Data.Entities;
using PizzaAPI.Data.Interfaces;
using System.Security.Claims;

namespace PizzaAPI.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public async Task<List<OrderSummaryDTO>> GetOrders(int accountid)
        {
            return await _orderRepo.GetOrders(accountid);
        }
        public async Task PostFoodType(FoodTypeEntity foodTypeEntity)
        {
            await _orderRepo.PostFoodType(foodTypeEntity);
        }

        public async Task<List<FoodTypeEntity>> GetFoodTypes()
        {
            return await _orderRepo.GetFoodTypes();
        }

        public async Task PostFood(FoodCreateDTO foodCreateDTO)
        {
            // Map FoodCreateDTO to FoodEntity
            var foodEntity = new FoodEntity
            {
                Name = foodCreateDTO.Name,
                Description = foodCreateDTO.Description,
                Price = foodCreateDTO.Price,
                FoodTypeID = foodCreateDTO.FoodTypeID,
                Ingredients = foodCreateDTO.Ingredients,
            };

            await _orderRepo.PostFood(foodEntity);
        }

        public Task<List<FoodEntity>> GetFoods()
        {
            return _orderRepo.GetFoods();
        }

        public async Task PostOrder(OrderDTO dto, int accountID)
        {
            var orderItems = new List<OrderItemEntity>();
            foreach (var i in dto.Items)
            {
                int price = await _orderRepo.GetFoodPrice(i.FoodID);
                orderItems.Add(new OrderItemEntity
                {
                    FoodID = i.FoodID,
                    Quantity = i.Quantity,
                    UnitPrice = price
                });
            }

            var order = new OrderEntity
            {
                AccountID = accountID,
                Items = orderItems
            };

            await _orderRepo.PostOrder(order);
        }
    }
}