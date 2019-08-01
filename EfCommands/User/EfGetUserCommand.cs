using Business.Commands.User;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.User
{
    public class EfGetUserCommand : EfBaseCommand, IGetUserCommand
    {
        public EfGetUserCommand(ShopContext context) : base(context)
        {

        }
        public ShowUserDto Execute(int request)
        {
            var user = Context.Users
                .Include(u => u.Role)
                .Where(u => u.Id == request).FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException("User");

            var dto = new ShowUserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleName = user.Role.Name,
                Username = user.Username,
            };
            return dto;
        }
    }
}
