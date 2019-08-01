using Business.DataTransferObjects;
using Business.Helpers;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.User
{
    public interface ILoginUserCommand : ICommand<LoginUser, LoggedUser>
    {
    }
}
