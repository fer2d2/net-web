using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaFernandoMoroBH0611.Models.ModelBinding
{
    public class CartBinding : IModelBinder
    {
        private const string SessionKey = "key";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = (controllerContext.HttpContext.Session != null) ?
                    (controllerContext.HttpContext.Session[SessionKey] as Cart) :
                    null;

            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[SessionKey] = cart;
            }

            return cart;
        }
    }
}