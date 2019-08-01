using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Basket;
using Business.DataTransferObjects;
using Business.Queries;
using Business.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.Basket
{
    public class EfGetAllBasketsCommand : EfBaseCommand, IGetAllBasketsCommand
    {
        public EfGetAllBasketsCommand(ShopContext context) : base(context)
        {
        }

        public PagedResponse<ShowBasketDto> Execute(BasketQuery request)
        {
            var query = Context.Baskets
                .Include(x => x.User)
                .Include(x => x.Product)
                .AsQueryable();            

            if (request.UserId.HasValue)
                query = query.Where(x => x.UserId == request.UserId);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowBasketDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(x =>new ShowBasketDto
                {
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    Username = x.User.Username
                })
                
            };
        }
    }
}
