using System;
using System.Collections.Generic;
using System.Text;
using Business.Commands.ProductPhoto;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.ProductPhoto
{
    public class EfDeleteProductPhotoCommand : EfBaseCommand, IDeleteProductPhotoCommand
    {
        public EfDeleteProductPhotoCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var pp = Context.ProductPhotos.Find(request);

            if (pp == null)
                throw new EntityNotFoundException("Product photo");

            Context.ProductPhotos.Remove(pp);
            Context.SaveChanges();
        }
    }
}
