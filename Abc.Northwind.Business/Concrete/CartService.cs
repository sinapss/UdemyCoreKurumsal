using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Northwind.Business.Concrete
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine=cart.Cartlines.FirstOrDefault(c=>c.Product.ProductId==product.ProductId);
            if(cartLine!=null)
            {
                cartLine.Quantity++;
                return;
            }
            cart.Cartlines.Add(new CartLine { Product=product,Quantity=1 });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.Cartlines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.Cartlines.Remove(cart.Cartlines.FirstOrDefault(c=>c.Product.ProductId== productId));
        }
    }
}
