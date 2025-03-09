using System.Diagnostics;
using Admin_PakoBlog.Models;
using Admin_PakoBlog.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Admin_PakoBlog.Controllers
{
    [UserFilter]
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly PakoBlogDbContext _dbContext;

        public AuthorController(ILogger<AuthorController> logger, PakoBlogDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> AddAuthor(Author author)
        {
            await _dbContext.AddAsync(author);

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteAuthor(int? ID)
        {
            _dbContext.Remove(_dbContext.Author.FirstOrDefault(a => a.ID == ID));
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
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
