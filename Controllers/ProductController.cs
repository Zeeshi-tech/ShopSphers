using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSphere.Data;
using ShopSphere.Models;

namespace ShopSphere.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        { _context = context; _env = env; }

        public async Task<IActionResult> Index(
    string? category,
    string? search)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p =>
                    p.Category != null &&
                    p.Category.ToLower() ==
                    category.ToLower());
            }

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p =>
                    p.Name.Contains(search));
            }

            var result = await products
                .Where(p => p.ImageUrl != null)
                .ToListAsync();

            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            ViewBag.Related = await _context.Products
                .Where(p => p.Category == product.Category && p.Id != id).Take(4).ToListAsync();
            return View(product);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (product.ImageFile != null)
            {
                string folder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string fileName = Guid.NewGuid() + Path.GetExtension(product.ImageFile.FileName);
                using var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create);
                await product.ImageFile.CopyToAsync(stream);
                product.ImageUrl = "/images/" + fileName;
            }
            else { product.ImageUrl = "https://via.placeholder.com/400x400?text=No+Image"; }
            if (product.OriginalPrice == 0) product.OriginalPrice = product.Price;
            product.IsApproved = true;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Product add ho gaya!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (product.ImageFile != null)
            {
                string folder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string fileName = Guid.NewGuid() + Path.GetExtension(product.ImageFile.FileName);
                using var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create);
                await product.ImageFile.CopyToAsync(stream);
                product.ImageUrl = "/images/" + fileName;
            }
            _context.Update(product);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Product update ho gaya!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p != null) { _context.Products.Remove(p); await _context.SaveChangesAsync(); }
            TempData["Success"] = "Product delete ho gaya!";
            return RedirectToAction(nameof(Index));
        }
    }
}
