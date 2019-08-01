using Business.Commands.User;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.User
{
    public class EfAddUserCommand : EfBaseCommand, IAddUserCommand
    {

        public EfAddUserCommand(ShopContext context) : base(context)
        {
        }
        public void Execute(UserDto request)
        {
            if (Context.Users.Any(u => u.Username == request.Username))
                throw new EntityAlreadyExistsException("User");

            if (Context.Users.Any(u => u.Email == request.Email))
                throw new EntityAlreadyExistsException("User");

            Context.Users.Add(new Domain.User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                RoleId = request.RoleId,
                Password = request.Password,
                Username = request.Username
            });
            Context.SaveChanges();
        }
    }
}
