using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.User
{
    public interface IDeleteUserCommand : ICommand<int>
    {
    }
}
