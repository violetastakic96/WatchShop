using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Mechanism;
using Business.DataTransferObjects;
using Business.Queries;
using Business.Responses;
using EfDataAccess;

namespace EfCommands.Mechanism
{
    public class EfGetMechanismsCommand : EfBaseCommand, IGetMechanismsCommand
    {
        public EfGetMechanismsCommand(ShopContext context) : base(context)
        {
        }

        public PagedResponse<MechanismDto> Execute(MechanismQuery request)
        {
            var query = Context.Mechanisms.AsQueryable();

            if (request.Name != null)
                query = query.Where(m => m.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<MechanismDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(m => new MechanismDto
                {
                    Id = m.Id,
                    Name = m.Name
                })
            };
        }
    }
}
