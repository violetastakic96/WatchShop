using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Basket;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Basket
{
    public class EfRemoveFromBasketCommand : EfBaseCommand, IRemoveFromBasketCommand
    {
        public EfRemoveFromBasketCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(RemoveBasketDto request)
        {
            var product = Context.Baskets.Where(x => x.UserId == request.UserId && x.ProductId == request.ProductId).FirstOrDefault();

            if (product == null)
                throw new EntityNotFoundException("Product in basket");

            var tmp = Context.Products.Find(product.ProductId);
            tmp.AvailCount += product.Quantity;
            Context.Baskets.Remove(product);
            Context.SaveChanges();
        }
    }
}
