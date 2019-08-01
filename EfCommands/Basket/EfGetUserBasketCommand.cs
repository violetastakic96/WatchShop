using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Basket;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.Basket
{
    public class EfGetUserBasketCommand : EfBaseCommand, IGetUserBasketCommand
    {
        public EfGetUserBasketCommand(ShopContext context) : base(context)
        {
        }

        public IEnumerable<ShowBasketDto> Execute(int request)
        {
            var basket = Context.Baskets
                .Include(x => x.User)
                .Include(x => x.Product)
                .Where(x => x.UserId == request);

            if (basket == null)
                throw new EntityNotFoundException("Basket");

            var res = basket.Select(x => new ShowBasketDto
            {
                ProductName = x.Product.Name,
                Quantity = x.Quantity,
                Username = x.User.Username
            });

            if (res.Count() == 0)
                throw new Exception("Basket is empty");
            else
                return res;
        }
    }
}
