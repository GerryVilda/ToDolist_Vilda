using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDolist_Vilda.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Instructions { get; set; }

        // Relationship
        public int RecipeTitleId { get; set; }
        public RecipeTitle RecipeTitle { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new();

        // Helper property (not mapped to DB)
        [NotMapped]
        public string TitleName { get; set; }
    }
}
