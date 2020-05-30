using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModels;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("Cart");

            _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart("Cart", cart);

            TempData.Add("message", product.ProductName + " added to cart");

            return RedirectToAction("Index", "Product");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = _cartSessionHelper.GetCart("Cart");

            _cartService.RemoveFromCart(cart, productId);

            _cartSessionHelper.SetCart("Cart", cart);

            TempData.Add("message", _productService.GetById(productId).ProductName + " removed from cart");

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Index()
        {
            var model = new CartListViewModel()
            {
                Cart = _cartSessionHelper.GetCart("Cart")
            };

            return View(model);
        }

        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel()
            {
                ShippingDetail = new ShippingDetail()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            TempData.Add("message", "Your order has completed successfully!");
            _cartSessionHelper.Clear();

            return RedirectToAction("Index", "Cart");
        }
    }
}
