using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using blog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace blog.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public  async Task <IActionResult> Index()
        {
            ViewBag.users = await _context.Users.ToListAsync();
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            var image = Image.FromStream(file.OpenReadStream());
            var resized = new Bitmap(image, new Size(256, 256));
            using var imageStream = new MemoryStream();
            resized.Save(imageStream, ImageFormat.Jpeg);
            var imageBytes = imageStream.ToArray();
            Convert.ToBase64String(imageBytes);

            return Redirect("/");
        }

    }
}
