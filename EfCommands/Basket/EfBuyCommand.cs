using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Basket;
using Business.Exceptions;
using Business.Interfaces;
using EfDataAccess;

namespace EfCommands.Basket
{
    public class EfBuyCommand : EfBaseCommand, IBuyCommand
    {
        private readonly IEmailSender _emailSender;
        public EfBuyCommand(ShopContext context, IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender;
        }

        public void Execute(int request)
        {
            var products = Context.Baskets.Where(x => x.UserId == request).ToList();

            if (products == null)
                throw new EntityNotFoundException("Product in basket");

            foreach (var product in products)
            {
                Context.Baskets.Remove(product);
            }
            Context.SaveChanges();

            _emailSender.Subject = "Successfully bought products";
            _emailSender.Body = "You successfully bought our products, thanks for your trust";
            _emailSender.ToEmail = Context.Users.Find(request).Email;
            _emailSender.Send();
        }
    }
}
