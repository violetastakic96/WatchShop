using Business.DataTransferObjects;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.User
{
    public interface IGetUserCommand : ICommand<int, ShowUserDto>
    {
    }
}
