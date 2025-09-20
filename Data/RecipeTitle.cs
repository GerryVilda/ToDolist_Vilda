public class RecipeTitle
{
    public int Id { get; set; }
    public string TitleName { get; set; } = string.Empty;

    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}

public class Recipe
{
    public int Id { get; set; }
    public int RecipeTitleId { get; set; }
    public string Instructions { get; set; } = string.Empty;

    public RecipeTitle RecipeTitle { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public double Measure { get; set; }
    public int RecipeId { get; set; }

    public Recipe Recipe { get; set; }
}
