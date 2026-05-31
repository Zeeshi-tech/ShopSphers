using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSphere.Data;
using ShopSphere.Models;

namespace ShopSphere.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // DASHBOARD
        public async Task<IActionResult> Index()
        {
            ViewBag.TotalProducts = await _context.Products.CountAsync();
            ViewBag.TotalOrders = await _context.Orders.CountAsync();
            ViewBag.TotalUsers = await _context.Users.CountAsync();
            ViewBag.TotalRevenue = await _context.Orders.SumAsync(o => o.TotalAmount);
            ViewBag.PendingOrders = await _context.Orders.CountAsync(o => o.OrderStatus == "Pending");
            ViewBag.SellerRequests = await _context.SellerRequests.CountAsync();

            var latestOrders = await _context.Orders
                .OrderByDescending(o => o.Id)
                .Take(10)
                .ToListAsync();

            return View(latestOrders);
        }

        // ALL ORDERS
        public async Task<IActionResult> Orders()
        {
            var orders = await _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
            return View(orders);
        }

        // UPDATE ORDER STATUS
        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.OrderStatus = status;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Orders));
        }

        // ALL PRODUCTS
        public async Task<IActionResult> Products()
        {
            var products = await _context.Products
                .OrderByDescending(p => p.Id)
                .ToListAsync();
            return View(products);
        }

        // DELETE PRODUCT (POST)
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            TempData["Success"] = "Product deleted!";
            return RedirectToAction(nameof(Products));
        }
    }
}
