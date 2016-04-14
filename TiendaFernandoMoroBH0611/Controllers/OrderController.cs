using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaFernandoMoroBH0611.Models;

namespace TiendaFernandoMoroBH0611.Controllers
{
    public class OrderController : Controller
    {
        private storeEntities1 storeEntities = new storeEntities1();

        // GET: Order
        public ActionResult Index()
        {
            var orders = storeEntities.Order.ToList();

            List<OrderListable> ordersForView = new List<OrderListable>();

            foreach (Order order in orders)
            {
                DateTime date = order.Datetime;
                String[] productsPurchasedEncoded = order.Products.Split(',');

                List<ProductToPurchase> purchasedProducts = new List<ProductToPurchase>();
                foreach(String productPurchasedEncoded in productsPurchasedEncoded) {
                    if(productPurchasedEncoded != "") {
                        String[] productPurchasedSplitted = productPurchasedEncoded.Split(':');
                        if (productPurchasedSplitted.Length == 2)
                        {
                            int productId = Int32.Parse(productPurchasedSplitted[0]);
                            int number = Int32.Parse(productPurchasedSplitted[1]);

                            Product product = storeEntities.Product.Find(productId);

                            if (product != null)
                            {
                                purchasedProducts.Add(new ProductToPurchase(product, number));
                            }
                        }
                    }

                }

                ordersForView.Add(new OrderListable(
                  order.Id, order.Datetime, purchasedProducts
                ));
            }

            return View(ordersForView);
        }
    }
}