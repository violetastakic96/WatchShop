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
    public class EfEditUserCommand : EfBaseCommand, IEditUserCommand
    {
        public EfEditUserCommand(ShopContext context) : base(context)
        {

        }

        public void Execute(UserDto request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null)
                throw new EntityNotFoundException("User");

            if (request.Username != user.Username && Context.Users.Any(u => u.Username == request.Username))
                throw new EntityAlreadyExistsException("User");

            if (request.Email != user.Email && Context.Users.Any(u => u.Email == request.Email))
                throw new EntityAlreadyExistsException("User");

            if (request.Password != null)
                user.Password = request.Password;

            user.Username = request.Username;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.RoleId = request.RoleId;

            Context.SaveChanges();
        }
    }
}
