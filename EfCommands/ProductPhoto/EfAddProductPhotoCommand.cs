using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.ProductPhoto;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.ProductPhoto
{
    public class EfAddProductPhotoCommand : EfBaseCommand, IAddProductPhotoCommand
    {
        public EfAddProductPhotoCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(ProductPhotoDto request)
        {
            if (!Context.Products.Any(p => p.Id == request.Id))
                throw new EntityNotFoundException("Product");

            Context.ProductPhotos.Add(new Domain.ProductPhoto
            {
                ProductId = request.Id,
                Alt = request.Alt,
                Path = request.Path
            });

            Context.SaveChanges();
        }
    }
}
