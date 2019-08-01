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
    public class EfAddToBasketCommand : EfBaseCommand, IAddToBasketCommand
    {
        public EfAddToBasketCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(BasketDto request)
        {
            if (!Context.Users.Any(x => x.Id == request.UserId))
                throw new EntityNotFoundException("User");

            if (!Context.Products.Any(x => x.Id == request.ProductId))
                throw new EntityNotFoundException("Product");

            var product = Context.Products.Find(request.ProductId);
            if (product.AvailCount < request.Quantity)
                throw new Exception("We dont' have that much products as you orderd.");

            if (Context.Baskets.Any(x => x.UserId == request.UserId && x.ProductId == request.ProductId))
            {
                var tmp = Context.Baskets.Where(x => x.UserId == request.UserId && x.ProductId == request.ProductId).FirstOrDefault();
                tmp.Quantity += request.Quantity;
            }
            else
            {
                Context.Baskets.Add(new Domain.Basket
                {
                    ProductId = request.ProductId,
                    UserId = request.UserId,
                    Quantity = request.Quantity
                });
            }

            product.AvailCount -= request.Quantity;
            Context.SaveChanges();
        }
    }
}
