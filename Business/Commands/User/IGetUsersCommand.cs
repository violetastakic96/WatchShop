using Business.DataTransferObjects;
using Business.Interfaces;
using Business.Queries;
using Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.User
{
    public interface IGetUsersCommand : ICommand<UserQuery, PagedResponse<ShowUserDto>>
    {
    }
}
