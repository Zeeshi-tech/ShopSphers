using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSphere.Data;
using ShopSphere.Models;

namespace ShopSphere.Controllers
{
    public class SellerController : Controller
    {
        private readonly AppDbContext _context;

        public SellerController(
            AppDbContext context)
        {
            _context = context;
        }

        // BECOME SELLER PAGE

        [HttpGet]
        public IActionResult BecomeSeller()
        {
            return View();
        }

        // SAVE SELLER REQUEST

        [HttpPost]
        public async Task<IActionResult> BecomeSeller(
            SellerRequest model)
        {
            if (ModelState.IsValid)
            {
                _context.SellerRequests.Add(model);

                await _context.SaveChangesAsync();

                TempData["Success"] =
                    "Seller request submitted successfully.";

                return RedirectToAction(
                    nameof(BecomeSeller));
            }

            return View(model);
        }

        // SHOW ALL REQUESTS

        public async Task<IActionResult> Requests()
        {
            var requests = await _context
                .SellerRequests
                .ToListAsync();

            return View(requests);
        }

        // APPROVE

        public async Task<IActionResult> Approve(
            int id)
        {
            var request = await _context
                .SellerRequests
                .FirstOrDefaultAsync(x => x.Id == id);

            if (request != null)
            {
                request.Status = "Approved";

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(
                nameof(Requests));
        }

        // REJECT

        public async Task<IActionResult> Reject(
            int id)
        {
            var request = await _context
                .SellerRequests
                .FirstOrDefaultAsync(x => x.Id == id);

            if (request != null)
            {
                request.Status = "Rejected";

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(
                nameof(Requests));
        }
    }
}