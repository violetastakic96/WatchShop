using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Product;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.Product
{
    public class EfGetProductCommand : EfBaseCommand, IGetProductCommand
    {
        public EfGetProductCommand(ShopContext context) : base(context)
        {
        }

        public ShowProductDto Execute(int request)
        {
            var product = Context.Products
                .Include(x => x.Brand)
                .Include(x => x.Gender)
                .Include(x => x.Mechanism)
                .Include(x => x.ProductPhotos)
                .FirstOrDefault(x => x.Id == request);

            if (product == null)
                throw new EntityNotFoundException("Product");

            return new ShowProductDto
            {
                Id = product.Id,
                AvailCount = product.AvailCount,
                Brand = product.Brand.Name,
                Description = product.Description,
                Gender = product.Gender.Name,
                Mechanism = product.Mechanism.Name,
                Name = product.Name,
                Price = product.Price,
                Warranty = product.Warranty,
                Waterproof = product.Waterproof,
                ProductPhotos = product.ProductPhotos.Select(x => new ProductPhotoDto
                {
                    Id = x.Id,
                    Alt = x.Alt,
                    Path = x.Path
                }).ToList()
            };
        }
    }
}
