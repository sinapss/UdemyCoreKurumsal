using Abc.Northwind.Mvc.WebUI.Models;
using Abc.Northwind.Mvc.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Abc.Northwind.Mvc.WebUI.ViewComponents
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private ICartSessionService _sessionService;
        public CartSummaryViewComponent(ICartSessionService sessionService)
        {
            _sessionService = sessionService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _sessionService.GetCart()
            };
            return View(model);
        }
    }
}
