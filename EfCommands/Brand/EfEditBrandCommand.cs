using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Brand;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Brand
{
    public class EfEditBrandCommand : EfBaseCommand, IEditBrandCommand
    {
        public EfEditBrandCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(BrandDto request)
        {
            var brand = Context.Brands.Find(request.Id);

            if (brand == null)
                throw new EntityNotFoundException("Brand");

            if (request.Name != brand.Name && Context.Roles.Any(b => b.Name == request.Name))
                throw new EntityAlreadyExistsException("Brand");

            brand.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
