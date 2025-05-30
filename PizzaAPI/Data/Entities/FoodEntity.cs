using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaAPI.Data.Entities
{
    public class FoodEntity
    {
        [Key]
        public int FoodID { get; set; }

        [Required]
        public int FoodTypeID { get; set; }

        [JsonIgnore]
        public FoodTypeEntity FoodType { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public List<string> Ingredients { get; set; } = new List<string>();
    }
}