using System;
using System.Collections.Generic;
using System.Text;
using Business.Commands.Brand;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Brand
{
    public class EfDeleteBrandCommand : EfBaseCommand, IDeleteBrandCommand
    {
        public EfDeleteBrandCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var brand = Context.Brands.Find(request);

            if (brand == null)
                throw new EntityNotFoundException("Role");

            Context.Brands.Remove(brand);
            Context.SaveChanges();
        }
    }
}
