using Business.Commands.User;
using Business.DataTransferObjects;
using Business.Helpers;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.User
{
    public class EfLoginUserCommand : EfBaseCommand, ILoginUserCommand
    {
        public EfLoginUserCommand(ShopContext context) : base(context)
        {
        }

        public LoggedUser Execute(LoginUser request)
        {
            var user = Context.Users.Include(u => u.Role).Where(u => u.Username == request.Username && u.Password == request.Password).FirstOrDefault();

            if (user == null)
                throw new Exception("Invalid username or password");

            return new LoggedUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.Name,
                Username = user.Username,
                Id = user.Id
            };
        }
    }
}
