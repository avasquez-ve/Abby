using AbbyWeb.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext AppDbContext;
        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(ApplicationDbContext dbContext)
        {
            AppDbContext = dbContext;
        }

        public void OnGet()
        {
            Categories = AppDbContext.Categories;
        }
    }
}
