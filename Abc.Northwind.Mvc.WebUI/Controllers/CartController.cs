using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;
using Abc.Northwind.Mvc.WebUI.Models;
using Abc.Northwind.Mvc.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Northwind.Mvc.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _sessionService;
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(ICartSessionService sessionService, ICartService cartService, IProductService productService)
        {
            _sessionService = sessionService;
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded=_productService.GetById(productId);
            var cart = _sessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);
            _sessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your product, {0}, was successfully added to the cart!", productToBeAdded.ProductName));
            return RedirectToAction("Index", "Product");
        }

        public ActionResult List()
        {
            var cart = _sessionService.GetCart();
            CartSummaryViewModel cartListViewModel = new CartSummaryViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }

        public ActionResult Remove(int productId) 
        {
            var cart = _sessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _sessionService.SetCart(cart);
            TempData.Add("message", "Your product was successfully removed from the cart!");
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message",String.Format("Thank you {0}, you order is in process", shippingDetails.FirstName));
            return View();
        }
    }
}
