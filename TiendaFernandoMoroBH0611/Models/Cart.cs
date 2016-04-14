using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaFernandoMoroBH0611.Models
{
    public class Cart : List<ProductToPurchase>
    {
        public decimal TotalAmount()
        {
            decimal amount = 0;
            foreach (ProductToPurchase productToPurchase in this)
            {
                amount += productToPurchase.product.Price;
            }

            return amount;
        }
    }
}