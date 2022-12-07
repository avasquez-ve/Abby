using AbbyWeb.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext ApplicationDbContext;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext dbContext)
        {
            ApplicationDbContext = dbContext;
        }
        public void OnGet(int id)
        {
            Category = ApplicationDbContext.Categories.Find(id); // Automatically find by the primary key of the table to return the result
            //Category = ApplicationDbContext.Categories.First(category => category.Id == id); // Is used to match with a column of your table --can throw ex if records are not find it
            //Category = ApplicationDbContext.Categories.FirstOrDefault(category => category.Id == id); // Is used to match with a column of your table --without throw ex
            //Category = ApplicationDbContext.Categories.Single(category => category.Id == id);// When you know that only 1 entity will be returnet --If is returned more than 1, a exception is throw it 
            //Category = ApplicationDbContext.Categories.SingleOrDefault(category => category.Id == id);// When you know that only 1 entity will be returnet --If is returned more than 1, it return null
            //Category = ApplicationDbContext.Categories.Where(category => category.Id == id).FirstOrDefault();//It return all the records that match it, if you add firsOrDefault, it return only the first
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = ApplicationDbContext.Categories.Find(Category.Id);

            if (categoryFromDb != null)
            {
                //It is required to find the entity because Remove method delete using an entity
                ApplicationDbContext.Categories.Remove(categoryFromDb);
                await ApplicationDbContext.SaveChangesAsync();
                TempData["Success"] = "Category deleted successfully.";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
