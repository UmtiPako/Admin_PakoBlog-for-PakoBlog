using System.Diagnostics;
using Admin_PakoBlog.Filter;
using Admin_PakoBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin_PakoBlog.Controllers
{
    [UserFilter]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly PakoBlogDbContext _dbContext;

        public CategoryController(ILogger<CategoryController> logger, PakoBlogDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> AddCategory(Category category)
        {
            await _dbContext.AddAsync(category);

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }
        public IActionResult DeleteCategory(int? ID)
        {
            _dbContext.Remove(_dbContext.Category.FirstOrDefault(c => c.ID == ID));
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Category));
        }

        public IActionResult Category()
        {
            List<Category> categories = _dbContext.Category.ToList();
            return View(categories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
