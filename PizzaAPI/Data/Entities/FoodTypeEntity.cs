using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PizzaAPI.Data.Entities
{
    public class FoodTypeEntity
    {
        [Key]
        public int FoodTypeID { get; set; }

        [Required]
        public string FoodTypeName { get; set; }
    }
}
