using OnlineShop.Abstract;
using OnlineShop.Models;
using System.Linq;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        public readonly ApplicationDbContext db;
        public readonly IOrderProcessor orderProcessor;

        public CartController()
        {
            db = new ApplicationDbContext();

        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }


        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpGet]
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }


        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }

        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = db.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = db.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

        // Cart GetCart() Helper for AddToCart and RemoveFromCart not needed after creating the CartModelBinder class and registering it in Global.asax
    }
}


