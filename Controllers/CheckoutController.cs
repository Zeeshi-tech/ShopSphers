using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSphere.Data;
using ShopSphere.Models;
using System.Net;
using System.Text.Json;

namespace ShopSphere.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        public CheckoutController(AppDbContext context) { _context = context; }

        private List<CartItem> GetCart() =>
            JsonSerializer.Deserialize<List<CartItem>>(
                HttpContext.Session.GetString("Cart") ?? "[]") ?? new();

        public IActionResult Index()
        {
            var cart = GetCart();
            if (!cart.Any()) return RedirectToAction("Index", "Cart");
            decimal subtotal = cart.Sum(c => c.Price * c.Quantity);
            ViewBag.Subtotal = subtotal;
            ViewBag.Shipping = subtotal >= 2000 ? 0 : 200;
            ViewBag.GrandTotal = subtotal + ViewBag.Shipping;
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(
            string fullName, string address, string phoneNumber,
            string paymentMethod, string? city, string? postalCode)
        {
            var cart = GetCart();
            if (!cart.Any()) return RedirectToAction("Index", "Cart");

            string userId = User.Identity?.IsAuthenticated == true
                ? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "guest"
                : "guest_" + (HttpContext.Session.GetString("GuestId") ?? Guid.NewGuid().ToString());

            HttpContext.Session.SetString("GuestId", userId.Replace("guest_", ""));

            decimal subtotal = cart.Sum(c => c.Price * c.Quantity);
            decimal shipping = subtotal >= 2000 ? 0 : 200;
            decimal total = subtotal + shipping;

            var order = new Order
            {
                OrderNumber = "SS" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                FullName = fullName,
                Address = address + (city != null ? $", {city}" : "") + (postalCode != null ? $" {postalCode}" : ""),
                PhoneNumber = phoneNumber,
                PaymentMethod = paymentMethod,
                TotalAmount = total,
                UserId = userId,
                OrderStatus = "Pending",
                PaymentStatus = paymentMethod == "Cash On Delivery" ? "Unpaid" : "Pending"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var item in cart)
            {
                _context.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    OrderId = order.Id
                });
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product != null && product.Stock >= item.Quantity)
                    product.Stock -= item.Quantity;
            }
            await _context.SaveChangesAsync();
            HttpContext.Session.Remove("Cart");

            if (paymentMethod == "JazzCash")
                return RedirectToAction(nameof(JazzCash), new { orderId = order.Id });
            if (paymentMethod == "EasyPaisa")
                return RedirectToAction(nameof(EasyPaisa), new { orderId = order.Id });

            return RedirectToAction(nameof(Success), new { orderId = order.Id });
        }

        public async Task<IActionResult> JazzCash(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmJazzCash(int orderId, string transactionId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null) { order.TransactionId = transactionId; order.PaymentStatus = "Paid"; order.OrderStatus = "Processing"; await _context.SaveChangesAsync(); }
            return RedirectToAction(nameof(Success), new { orderId });
        }

        public async Task<IActionResult> EasyPaisa(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEasyPaisa(int orderId, string transactionId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null) { order.TransactionId = transactionId; order.PaymentStatus = "Paid"; order.OrderStatus = "Processing"; await _context.SaveChangesAsync(); }
            return RedirectToAction(nameof(Success), new { orderId });
        }

        public async Task<IActionResult> Success(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
            return View(order);
        }
        
    }
}
