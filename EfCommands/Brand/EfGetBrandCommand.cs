using System;
using System.Collections.Generic;
using System.Text;
using Business.Commands.Brand;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Brand
{
    public class EfGetBrandCommand : EfBaseCommand, IGetBrandCommand
    {
        public EfGetBrandCommand(ShopContext context) : base(context)
        {
        }

        public BrandDto Execute(int request)
        {
            var brand = Context.Brands.Find(request);

            if (brand == null)
                throw new EntityNotFoundException("Role");

            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }
    }
}
