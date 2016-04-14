using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaFernandoMoroBH0611.Models;

namespace TiendaFernandoMoroBH0611.Controllers
{
    public class CartController : Controller
    {
        private storeEntities1 storeEntities = new storeEntities1();

        // GET: Cart
        public ActionResult Index(Cart cart)
        {
            return View(cart);
        }

        public ActionResult Add(Cart cart, int id)
        {
            Product product = storeEntities.Product.Find(id);

            var found = cart.Where(productToPurchase => productToPurchase.product.Id == product.Id);

            if (product.Stock > 0)
            {
                if (found.Count() == 0)
                {
                    cart.Add(new ProductToPurchase(product, 1));
                }
                else
                {
                    cart.Find(productToPurchase => productToPurchase.product.Id == product.Id).number++;
                }
            }

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Delete(Cart cart, int id)
        {
            var productToPurchaseFound = cart.Find(productToPurchase => productToPurchase.product.Id == id);

            if (productToPurchaseFound.number == 1)
            {
                cart.Remove(productToPurchaseFound);
            }
            else
            {
                productToPurchaseFound.number--;
            }

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Purchase(Cart cart)
        {
            foreach(ProductToPurchase productToPurchase in cart) {
                if (productToPurchase.number > productToPurchase.product.Stock)
                {
                    TempData["errorMessage"] = "Error: you can't buy more products than the currently available in stock";
                    return RedirectToAction("Index", "Cart");
                }
            }

            DecrementStock(cart);
            AddOrder(cart);
            cart.Clear();

            TempData["successMessage"] = "Your purchase has been completed successfully";
            return RedirectToAction("Index", "Products");
        }

        private void DecrementStock(Cart cart)
        {
            foreach (ProductToPurchase productToPurchase in cart)
            {
                Product product = storeEntities.Product.Find(productToPurchase.product.Id);
                product.Stock -= productToPurchase.number;
                storeEntities.SaveChanges();
            }
        }

        private void AddOrder(Cart cart)
        {
            Order order = new Order();
            order.Datetime = DateTime.Now;
            foreach (ProductToPurchase productToPurchase in cart)
            {
                order.Products += productToPurchase.product.Id + ":" + productToPurchase.number + ",";
            }
            storeEntities.Order.Add(order);
            storeEntities.SaveChanges();
        }
    }
}
