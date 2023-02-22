using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Mvc.WebUI.Models
{
    public class ProductUpdateViewModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}
