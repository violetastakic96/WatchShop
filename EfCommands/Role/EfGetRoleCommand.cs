using Business.Commands.Role;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Role
{
    public class EfGetRoleCommand : EfBaseCommand, IGetRoleCommand
    {
        public EfGetRoleCommand(ShopContext context) : base(context)
        {
        }

        public ShowRoleDto Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null)
                throw new EntityNotFoundException("Role");

            return new ShowRoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
