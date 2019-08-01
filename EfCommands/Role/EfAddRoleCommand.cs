using Business.Commands.Role;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Role
{
    public class EfAddRoleCommand : EfBaseCommand, IAddRoleCommand
    {
        public EfAddRoleCommand(ShopContext context) : base(context)
        {
        }
        public void Execute(RoleDto request)
        {
            if (Context.Roles.Any(r => r.Name == request.Name))
                throw new EntityAlreadyExistsException("Role");

            Context.Roles.Add(new Domain.Role
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
