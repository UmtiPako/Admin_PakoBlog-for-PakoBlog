using System.Diagnostics;
using Admin_PakoBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin_PakoBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PakoBlogDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, PakoBlogDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        public IActionResult Login(string Email, string Password)
        {
            var author = _dbContext.Author.FirstOrDefault(a => a.Email == Email && 
            a.Password == Password);

            if (author == null)
            {
                return RedirectToAction(nameof(Index));
            }

            HttpContext.Session.SetInt32("id", author.ID);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
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

        public async Task<IActionResult> AddAuthor(Author author)
        {
            await _dbContext.AddAsync(author);

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Author));
        }
        public IActionResult DeleteAuthor(int? ID)
        {
            _dbContext.Remove(_dbContext.Author.FirstOrDefault(a => a.ID == ID));
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Author));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category()
        {
            List<Category> categories = _dbContext.Category.ToList();
            return View(categories);
        }

        public IActionResult Author()
        {
            List<Author> authors = _dbContext.Author.ToList();
            return View(authors);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
