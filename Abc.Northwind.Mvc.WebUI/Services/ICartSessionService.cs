using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.Mvc.WebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
