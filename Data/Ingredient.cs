using System.ComponentModel.DataAnnotations;

namespace ToDolist_Vilda.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // e.g., Flour, Sugar

        [Required]
        public string UnitOfMeasure { get; set; } // e.g., grams, cups

        [Required]
        public double Measure { get; set; } // e.g., 200, 2

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
