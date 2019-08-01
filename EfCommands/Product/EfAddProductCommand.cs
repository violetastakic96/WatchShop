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
    public class EfAddProductCommand : EfBaseCommand, IAddProductCommand
    {
        public EfAddProductCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(ProductDto request)
        {
            if (Context.Products.Any(p => p.Name == request.Name))
                throw new EntityAlreadyExistsException("Product");

            if (!Context.Brands.Any(p => p.Id == request.BrandId))
                throw new EntityNotFoundException("Brand");

            if (!Context.Mechanisms.Any(c => c.Id == request.MechanismId))
                throw new EntityNotFoundException("Mechanism");

            if (!Context.Genders.Any(c => c.Id == request.GenderId))
                throw new EntityNotFoundException("Gender");


            Context.Products.Add(new Domain.Product
            {
                Name = request.Name,
                GenderId = request.GenderId,
                MechanismId = request.MechanismId,
                BrandId = request.BrandId,
                AvailCount = request.AvailCount,
                Description = request.Description,
                Price = request.Price,
                Warranty = request.Warranty,
                Waterproof = request.Waterproof                
            });

            Context.SaveChanges();
        }
    }
}
