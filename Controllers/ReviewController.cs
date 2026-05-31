using Microsoft.AspNetCore.Mvc;
using ShopSphere.Data;
using ShopSphere.Models;

namespace ShopSphere.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewController(
            AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            Review review)
        {
            _context.Reviews.Add(review);

            await _context.SaveChangesAsync();

            return RedirectToAction(
                "Details",
                "Product",
                new { id = review.ProductId });
        }
    }
}
