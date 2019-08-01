using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.User;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.User
{
    public class EfGetUserForEditCommand : EfBaseCommand, IGetUserForEditCommand
    {
        public EfGetUserForEditCommand(ShopContext context) : base(context)
        {
        }

        public UserDto Execute(int request)
        {
            var user = Context.Users
                .Where(u => u.Id == request).FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException("User");

            var dto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = user.RoleId,
                Username = user.Username
            };
            return dto;
        }
    }
}
