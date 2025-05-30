using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PizzaAPI.Data;
using PizzaAPI.Data.DTOs;
using PizzaAPI.Data.Entities;
using PizzaAPI.Data.Interfaces;

namespace PizzaAPI.Data.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly PizzaContext _context;
        public OrderRepo(PizzaContext context)
        {
            _context = context;
        }
        public async Task<List<OrderSummaryDTO>> GetOrders(int accountid)
        {
            return await _context.Orders
                        .AsNoTracking()
                        .Where(o => o.AccountID == accountid)
                        .Select(o => new OrderSummaryDTO
                        {
                            OrderID = o.OrderID,
                            TotalPrice = o.Items.Sum(i => i.UnitPrice * i.Quantity),
                            Items = o.Items
                                .Select(i => new OrderItemSummaryDTO
                                {
                                    Name = i.Food.Name,
                                    Quantity = i.Quantity
                                })
                                .ToList()
                        })
                        .ToListAsync();
        }

        public async Task PostFoodType(FoodTypeEntity foodTypeEntity)
        {
            await _context.FoodTypes.AddAsync(foodTypeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FoodTypeEntity>> GetFoodTypes()
        {
            return await _context.FoodTypes.ToListAsync();
        }

        public async Task PostFood(FoodEntity foodEntity)
        {
            await _context.Foods.AddAsync(foodEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FoodEntity>> GetFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task PostOrder(OrderEntity orderEntity)
        {
            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetFoodPrice(int foodID)
        {
            return _context.Foods.FirstOrDefault(f => f.FoodID == foodID).Price;
        }
    }
}
