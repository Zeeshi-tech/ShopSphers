using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSphere.Data;

namespace ShopSphere.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Where(p => p.IsApproved)
                .OrderByDescending(p => p.Id)
                .Take(20)
                .ToListAsync();
            return View(products);
        }

        public IActionResult Privacy() => View();
    }
}