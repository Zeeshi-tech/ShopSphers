using Microsoft.AspNetCore.Mvc;
using ShopSphere.Data;
using ShopSphere.Models;
using System.Text.Json;

namespace ShopSphere.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // ADD TO CART

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            var sessionCart = HttpContext.Session.GetString("Cart");

            List<CartItem> cart = string.IsNullOrEmpty(sessionCart)
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(sessionCart)!;

            var existing = cart.FirstOrDefault(c => c.ProductId == id);

            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = quantity
                });
            }

            HttpContext.Session.SetString(
                "Cart",
                JsonSerializer.Serialize(cart));

            TempData["CartMsg"] = $"{product.Name} added to cart";

            return RedirectToAction("Index");
        }

        

        // CART PAGE

        public IActionResult Index()
        {
            List<CartItem> cart =
                new List<CartItem>();

            var sessionCart =
                HttpContext.Session.GetString("Cart");

            if (!string.IsNullOrEmpty(sessionCart))
            {
                cart = JsonSerializer.Deserialize<List<CartItem>>(sessionCart);
            }

            return View(cart);
        }

        // REMOVE

        public IActionResult Remove(int id)
        {
            var sessionCart =
                HttpContext.Session.GetString("Cart");

            if (!string.IsNullOrEmpty(sessionCart))
            {
                var cart =
                    JsonSerializer.Deserialize<List<CartItem>>(sessionCart);

                var item =
                    cart.FirstOrDefault(c => c.ProductId == id);

                if (item != null)
                {
                    cart.Remove(item);
                }

                HttpContext.Session.SetString(
                    "Cart",
                    JsonSerializer.Serialize(cart));
            }

            return RedirectToAction("Index");
        }
        public IActionResult Count()
        {
            var sessionCart = HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(sessionCart))
                return Json(0);

            var cart = JsonSerializer.Deserialize<List<CartItem>>(sessionCart);

            return Json(cart.Sum(x => x.Quantity));
        }
        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            var sessionCart = HttpContext.Session.GetString("Cart");

            if (!string.IsNullOrEmpty(sessionCart))
            {
                var cart =
                    JsonSerializer.Deserialize<List<CartItem>>(sessionCart)!;

                var item =
                    cart.FirstOrDefault(c => c.ProductId == id);

                if (item != null)
                {
                    if (quantity <= 0)
                    {
                        cart.Remove(item);
                    }
                    else
                    {
                        item.Quantity = quantity;
                    }
                }

                HttpContext.Session.SetString(
                    "Cart",
                    JsonSerializer.Serialize(cart));
            }

            return RedirectToAction("Index");
        }
    }
}
