using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Gender;
using Business.DataTransferObjects;
using Business.Queries;
using Business.Responses;
using EfDataAccess;

namespace EfCommands.Gender
{
    public class EfGetGendersCommand : EfBaseCommand, IGetGendersCommand
    {
        public EfGetGendersCommand(ShopContext context) : base(context)
        {
        }

        public PagedResponse<GenderDto> Execute(GenderQuery request)
        {
            var query = Context.Genders.AsQueryable();

            if (request.Name != null)
                query = query.Where(g => g.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<GenderDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(b => new GenderDto
                {
                    Id = b.Id,
                    Name = b.Name
                })
            };
        }
    }
}
