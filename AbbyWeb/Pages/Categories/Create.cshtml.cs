using AbbyWeb.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext ApplicationDbContext;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext dbContext)
        {
            ApplicationDbContext = dbContext;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(Category.Name, "The Name cannot exactly match the Display order");
                //ModelState.AddModelError("", "The Name cannot exactly match the Display order"); -> Para mostrarlo solamente en el asp-validation-summary="All"
            }
            if (ModelState.IsValid)
            {
                await ApplicationDbContext.Categories.AddAsync(Category);
                await ApplicationDbContext.SaveChangesAsync();
                TempData["Success"] = "Category created successfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
