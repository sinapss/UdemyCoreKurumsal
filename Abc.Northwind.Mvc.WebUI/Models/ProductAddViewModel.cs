using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Mvc.WebUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; internal set; }
    }
}
