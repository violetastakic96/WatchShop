using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Product;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Product
{
    public class EfGetProductForEditCommand : EfBaseCommand, IGetProductForEditCommand
    {
        public EfGetProductForEditCommand(ShopContext context) : base(context)
        {
        }

        public ProductDto Execute(int request)
        {
            var product = Context.Products
               .FirstOrDefault(x => x.Id == request);

            if (product == null)
                throw new EntityNotFoundException("Product");

            return new ProductDto
            {
                Id = product.Id,
                AvailCount = product.AvailCount,
                BrandId = product.BrandId,
                Description = product.Description,
                GenderId = product.GenderId,
                MechanismId = product.MechanismId,
                Name = product.Name,
                Price = product.Price,
                Warranty = product.Warranty,
                Waterproof = product.Waterproof               
            };
        }
    }
}
