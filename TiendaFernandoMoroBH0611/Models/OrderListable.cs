using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaFernandoMoroBH0611.Models
{
    public class OrderListable
    {
        public int id {get; set;}
        public DateTime datetime { get; set; }
        public List<ProductToPurchase> productPurchased {get; set;}

        public OrderListable(int id, DateTime datetime, List<ProductToPurchase> productPurchased)
        {
            this.id = id;
            this.datetime = datetime;
            this.productPurchased = productPurchased;
        }
    }
}