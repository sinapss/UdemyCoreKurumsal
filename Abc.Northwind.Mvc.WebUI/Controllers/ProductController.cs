﻿using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Mvc.WebUI.ExtensionMethod;
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
        public ActionResult Index(int page=1, int category=0)
        {
            var pageSize = 10;
            var products = _productService.GetByCategory(category);
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page-1)*pageSize).Take(pageSize).ToList(),
                PageCount=(int)Math.Ceiling(products.Count/(double)pageSize),
                PageSize=pageSize,
                CurrentCategory=category,
                CurrentPage=page
            };
            return View(model);
        }
        
    }
}
