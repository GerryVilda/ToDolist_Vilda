using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDolist_Vilda.Models
{
    public class RecipeTitle
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string TitleName { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
