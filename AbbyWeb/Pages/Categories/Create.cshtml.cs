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
            if (ModelState.IsValid)
            {
                await ApplicationDbContext.Categories.AddAsync(Category);
                await ApplicationDbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
