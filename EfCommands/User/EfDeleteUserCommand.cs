using Business.Commands.User;
using Business.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.User
{
    public class EfDeleteUserCommand : EfBaseCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(ShopContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null)
                throw new EntityNotFoundException("User");

            Context.Users.Remove(user);
            Context.SaveChanges();
        }
    }
}
