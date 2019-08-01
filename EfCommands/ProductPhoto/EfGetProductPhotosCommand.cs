using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.ProductPhoto;
using Business.DataTransferObjects;
using Business.Queries;
using Business.Responses;
using EfDataAccess;

namespace EfCommands.ProductPhoto
{
    public class EfGetProductPhotosCommand : EfBaseCommand, IGetProductPhotosCommand
    {
        public EfGetProductPhotosCommand(ShopContext context) : base(context)
        {
        }

        public PagedResponse<ShowProductPhoto> Execute(ProductPhotoQuery request)
        {
            var query = Context.ProductPhotos.AsQueryable();

            if (request.ProductId != null)
                query = query.Where(lp => lp.ProductId == request.ProductId);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowProductPhoto>
            {

                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(pp => new ShowProductPhoto
                {
                    Alt = pp.Alt,
                    ProductName = pp.Product.Name,
                    Path = pp.Path
                })

            };
        }
    }
}
