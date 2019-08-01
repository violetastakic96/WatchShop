using System;
using System.Collections.Generic;
using System.Text;
using Business.Commands.ProductPhoto;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.ProductPhoto
{
    public class EfEditProductPhotoCommand : EfBaseCommand, IEditProductPhotoCommand
    {
        public EfEditProductPhotoCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(ProductPhotoDto request)
        {
            var pp = Context.ProductPhotos.Find(request);

            if (pp == null)
                throw new EntityNotFoundException("Product photo");

            pp.Alt = request.Alt;

            Context.SaveChanges();
        }
    }
}
