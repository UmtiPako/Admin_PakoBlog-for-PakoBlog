using System.Diagnostics;
using Admin_PakoBlog.Filter;
using Admin_PakoBlog.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Admin_PakoBlog.Controllers

{
    [UserFilter]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly PakoBlogDbContext _dbContext;

        public PostController(ILogger<PostController> logger, PakoBlogDbContext dbContext,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Post> posts = _dbContext.Post.ToList();
            return View(posts);
        }

        public IActionResult Post()
        {
            ViewBag.Categories = _dbContext.Category.Select(w =>
                new SelectListItem
                {
                    Text = w.Name,
                    Value = w.ID.ToString()
                }
            ).ToList();
            return View();
        }
        public IActionResult DeletePost(int? ID)
        {
            _dbContext.Remove(_dbContext.Post.FirstOrDefault(p => p.ID == ID));
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Publish(int id)
        {
            var post = _dbContext.Post.FirstOrDefault(p => p.ID == id);

            post.isPublished = true;
            post.publishTime = DateTime.Now;

            _dbContext.Update(post);

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Save(Post model)
        {
            if (model == null || Request.Form.Files.Count == 0)
            {
                return Json(false);
            }

            var file = Request.Form.Files.First();

            if (file.Length == 0) // Boş dosya kontrolü
            {
                return Json(false);
            }

            try
            {
                // IWebHostEnvironment üzerinden wwwroot yolunu al
                string otherProjectPath = @"C:\Users\umutp\source\repos\PakoBlog\PakoBlog\wwwroot";
                string savePath = Path.Combine(otherProjectPath, "img");

                // Benzersiz dosya adı oluştur
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string fileUrl = Path.Combine(savePath, fileName);

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                // Dosyayı kaydet
                using (var fileStream = new FileStream(fileUrl, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Model güncelleme
                model.ImagePath = fileName;
                var authorId = HttpContext.Session.GetInt32("id");
                if (authorId == null)
                {
                    return Json(new { success = false, message = "User is not authenticated" });
                }
                model.AuthorID = authorId.Value;

                await _dbContext.AddAsync(model);
                await _dbContext.SaveChangesAsync();

                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

