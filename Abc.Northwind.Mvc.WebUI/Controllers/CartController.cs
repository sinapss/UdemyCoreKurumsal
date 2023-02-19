using Abc.Northwind.Business.Abstract;
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
    }
}
