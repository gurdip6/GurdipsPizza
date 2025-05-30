using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data.Entities;

namespace PizzaAPI.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {
        }

        public virtual DbSet<AccountEntity> Accounts { get; set; }
        public virtual DbSet<FoodEntity> Foods { get; set; }
        public virtual DbSet<FoodTypeEntity> FoodTypes { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<OrderItemEntity> OrderItems { get; set; }
    }
}