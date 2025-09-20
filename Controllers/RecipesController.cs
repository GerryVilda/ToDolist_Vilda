using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDolist_Vilda.Data;
using ToDolist_Vilda.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ToDolist_Vilda.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipeDbContext _context;

        public RecipesController(RecipeDbContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var recipes = await _context.Recipes
                .Include(r => r.RecipeTitle)
                .Include(r => r.Ingredients)
                .ToListAsync();

            return View(recipes);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                // Check if a RecipeTitle with the same name already exists
                var existingTitle = await _context.RecipeTitles
                                                  .FirstOrDefaultAsync(t => t.TitleName == recipe.TitleName);

                if (existingTitle != null)
                {
                    // Use the existing title
                    recipe.RecipeTitleId = existingTitle.Id; // Set FK
                }
                else
                {
                    // Create a new title
                    var newTitle = new RecipeTitle { TitleName = recipe.TitleName };
                    _context.RecipeTitles.Add(newTitle);
                    await _context.SaveChangesAsync(); // Save first to get the ID

                    recipe.RecipeTitleId = newTitle.Id; // Set FK
                }

                // Add the recipe itself to the context
                _context.Recipes.Add(recipe);

                // Save changes
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(recipe);
        }

    }
}