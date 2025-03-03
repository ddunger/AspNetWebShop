﻿using AspNetWebShop.Data;
using AspNetWebShop.Extensions;
using AspNetWebShop.Models.CartData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebShop.Controllers
{
    [Authorize]
    public class CartController(ApplicationDbContext context) : Controller
    {
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetCart();

            ViewData["CartCount"] = cart.Items.Count;

            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var cart = HttpContext.Session.GetCart();

            if (cart.Items.Count == 0)
            {
                var item = new CartItem
                {
                    Product = context.Products.Find(productId)!,
                    Quantity = 1
                };

                cart.Items.Add(item);
            }
            else
            {
                if (cart.Items.Any(x => x.Product.Id == productId))
                {
                    var item = cart.Items.Single(x => x.Product.Id.Equals(productId));
                    item.Quantity++;
                }
                else
                {
                    var item = new CartItem
                    {
                        Product = context.Products.Find(productId)!,
                        Quantity = 1
                    };

                    cart.Items.Add(item);
                }
            }

            HttpContext.Session.SetCart(cart);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.GetCart();

            if (cart.Items.Any(x => x.Product.Id == productId))
            {
                var item = cart.Items.Single(x => x.Product.Id.Equals(productId));
                cart.Items.Remove(item);
            }

            HttpContext.Session.SetCart(cart);

            return RedirectToAction(nameof(Index));
        }
    }
}
