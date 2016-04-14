using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaFernandoMoroBH0611.Models
{
    public class ProductToPurchase
    {
        public Product product { get; set; }
        public int number { get; set; }

        public ProductToPurchase(Product product, int number) {
            this.product = product;
            this.number = number;
        }
    }
}