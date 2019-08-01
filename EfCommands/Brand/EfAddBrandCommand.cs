using Business.Commands.Brand;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Brand
{
    public class EfAddBrandCommand : EfBaseCommand, IAddBrandCommand
    {
        public EfAddBrandCommand(ShopContext context) : base(context)
        {
        }
       
        public void Execute(BrandDto request)
        {
            if (Context.Brands.Any(b => b.Name == request.Name))
                throw new EntityAlreadyExistsException("Brand");

            Context.Brands.Add(new Domain.Brand
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
