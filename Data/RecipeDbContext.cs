using Microsoft.EntityFrameworkCore;
using ToDolist_Vilda.Models;

namespace ToDolist_Vilda.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
            : base(options) { }

        public DbSet<RecipeTitle> RecipeTitles { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Title
            modelBuilder.Entity<RecipeTitle>().HasData(
                new RecipeTitle { Id = 1, TitleName = "Pancakes" }
            );

            // Seed Recipe
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { Id = 1, RecipeTitleId = 1, Instructions = "Mix ingredients and fry." }
            );

            // Seed Ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Flour", UnitOfMeasure = "cups", Measure = 2, RecipeId = 1 },
                new Ingredient { Id = 2, Name = "Milk", UnitOfMeasure = "cups", Measure = 1.5, RecipeId = 1 },
                new Ingredient { Id = 3, Name = "Eggs", UnitOfMeasure = "pcs", Measure = 2, RecipeId = 1 }
            );
        }

    }
}
