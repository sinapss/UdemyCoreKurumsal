using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Mvc.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Northwind.Mvc.WebUI.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService= productService;
        }
        public ActionResult Index()
        {
            var products = _productService.GetAll();
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products
            };
            return View(model);
        }
    }
}
