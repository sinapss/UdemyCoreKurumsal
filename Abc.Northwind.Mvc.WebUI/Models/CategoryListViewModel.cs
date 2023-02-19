using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Mvc.WebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; internal set; }
        public int CurrentCategory { get; internal set; }
    }
}
