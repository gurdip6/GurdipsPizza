using PizzaAPI.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PizzaAPI.Data.DTOs
{
    public class FoodCreateDTO
    {
        [Required]
        public int FoodTypeID { get; set; }

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
