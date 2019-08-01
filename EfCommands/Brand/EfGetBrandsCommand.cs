using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Brand;
using Business.DataTransferObjects;
using Business.Queries;
using Business.Responses;
using EfDataAccess;

namespace EfCommands.Brand
{
    public class EfGetBrandsCommand : EfBaseCommand, IGetBrandsCommand
    {
        public EfGetBrandsCommand(ShopContext context) : base(context)
        {
        }

        public PagedResponse<BrandDto> Execute(BrandQuery request)
        {
            var query = Context.Brands.AsQueryable();

            if (request.Name != null)
                query = query.Where(b => b.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<BrandDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(b => new BrandDto
                {
                    Id = b.Id,
                    Name = b.Name
                })
            };
        }
    }
}
