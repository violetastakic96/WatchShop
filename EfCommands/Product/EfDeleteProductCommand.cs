using System;
using System.Collections.Generic;
using System.Text;
using Business.Commands.Product;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Product
{
    public class EfDeleteProductCommand : EfBaseCommand, IDeleteProductCommand
    {
        public EfDeleteProductCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var product = Context.Products.Find(request);

            if (product == null)
                throw new EntityNotFoundException("Product");

            Context.Products.Remove(product);
            Context.SaveChanges();
        }
    }
}
