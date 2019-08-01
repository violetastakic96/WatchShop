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
    public class EfEditProductCommand : EfBaseCommand, IEditProductCommand
    {
        public EfEditProductCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(ProductDto request)
        {
            var product = Context.Products.Find(request.Id);

            if (product == null)
                throw new EntityNotFoundException("Product");

            if (product.Name != request.Name && Context.Products.Any(p => p.Name == request.Name))
                throw new EntityAlreadyExistsException("Product");

            if (!Context.Brands.Any(p => p.Id == request.BrandId))
                throw new EntityNotFoundException("City");

            if (!Context.Mechanisms.Any(c => c.Id == request.MechanismId))
                throw new EntityNotFoundException("Mechanism");

            if (!Context.Genders.Any(c => c.Id == request.GenderId))
                throw new EntityNotFoundException("Gender");

            product.Name = request.Name;
            product.Price = request.Price;
            product.AvailCount = request.AvailCount;
            product.BrandId = request.BrandId;
            product.Description = request.Description;
            product.GenderId = request.GenderId;
            product.MechanismId = request.MechanismId;
            product.Warranty = request.Warranty;
            product.Waterproof = request.Waterproof;

            Context.SaveChanges();
        }
    }
}
