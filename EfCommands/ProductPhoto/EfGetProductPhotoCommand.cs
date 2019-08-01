using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.ProductPhoto;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.ProductPhoto
{
    public class EfGetProductPhotoCommand : EfBaseCommand, IGetProductPhotoCommand
    {
        public EfGetProductPhotoCommand(ShopContext context) : base(context)
        {
        }

        public ShowProductPhoto Execute(int request)
        {
            var pp = Context.ProductPhotos
                .Include(p => p.Product)
                .Where(p => p.Id == request).FirstOrDefault();

            if (pp == null)
                throw new EntityNotFoundException("Product Photo");


            return new ShowProductPhoto
            {
                ProductName = pp.Product.Name,
                Alt = pp.Alt,
                Path = pp.Path
            };
        }
    }
}
