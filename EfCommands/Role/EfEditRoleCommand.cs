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
    public class EfEditRoleCommand : EfBaseCommand, IEditRoleCommand
    {
        public EfEditRoleCommand(ShopContext context) : base(context)
        {

        }
        public void Execute(RoleDto request)
        {
            var role = Context.Roles.Find(request.Id);

            if (role == null)
                throw new EntityNotFoundException("Role");

            if (request.Name != role.Name && Context.Roles.Any(r => r.Name == request.Name))
                throw new EntityAlreadyExistsException("Role");

            role.Name = request.Name;

            Context.SaveChanges();

        }
    }
}
