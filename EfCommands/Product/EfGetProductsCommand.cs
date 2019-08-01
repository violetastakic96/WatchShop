using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Product;
using Business.DataTransferObjects;
using Business.Queries;
using Business.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.Product
{
    public class EfGetProductsCommand : EfBaseCommand, IGetProductsCommand
    {
        public EfGetProductsCommand(ShopContext context) : base(context)
        {
        }

        public PagedResponse<ShowProductDto> Execute(ProductQuery request)
        {
            var query = Context.Products
                .Include(x => x.Brand)
                .Include(x => x.Gender)
                .Include(x => x.Mechanism)
                .Include(x => x.ProductPhotos)
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            if (request.MinPrice != null)
                query = query.Where(x => x.Price >= request.MinPrice);

            if (request.MaxPrice != null)
                query = query.Where(x => x.Price <= request.MaxPrice);

            if (request.Waterproof != null)
                query = query.Where(x => x.Waterproof == request.Waterproof);

            if (request.IsAvailable != null)
            {
                if (request.IsAvailable == true)
                    query = query.Where(x => x.AvailCount > 0);

                if (request.IsAvailable == false)
                    query = query.Where(x => x.AvailCount == 0);
            }
                
            if (request.MechanismId.HasValue)
                query = query.Where(x => x.MechanismId == request.MechanismId);

            if (request.GenderId.HasValue)
                query = query.Where(x => x.GenderId == request.GenderId);

            if (request.BrandId.HasValue)
                query = query.Where(x => x.BrandId == request.BrandId);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowProductDto>
            {

                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(p => new ShowProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    AvailCount = p.AvailCount,
                    Brand = p.Brand.Name,
                    Description = p.Description,
                    Gender = p.Gender.Name,
                    Mechanism = p.Mechanism.Name,
                    Price = p.Price,
                    Warranty = p.Warranty,
                    Waterproof = p.Waterproof,
                    ProductPhotos = p.ProductPhotos.Select(x => new ProductPhotoDto
                    {
                        Id = x.Id,
                        Alt = x.Alt,
                        Path = x.Path
                    }).ToList()
                })

            };


        }
    }
}
