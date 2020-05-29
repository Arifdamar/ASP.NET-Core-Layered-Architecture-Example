using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModels;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(line => line.Product.ProductId == product.ProductId);

            if (cartLine != null)
            {
                cartLine.Quantity++;
            }
            else
            {
                cart.CartLines.Add(new CartLine() { Product = product, Quantity = 1 });
            }
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(line => line.Product.ProductId == productId));
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }
    }
}
