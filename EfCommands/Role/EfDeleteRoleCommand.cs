using Business.Commands.Role;
using Business.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Role
{
    public class EfDeleteRoleCommand : EfBaseCommand, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(ShopContext context) : base(context)
        {
        }
        public void Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null)
                throw new EntityNotFoundException("Role");

            Context.Roles.Remove(role);
            Context.SaveChanges();
        }
    }
}
