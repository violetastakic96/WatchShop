using Business.DataTransferObjects;
using Business.Interfaces;
using Business.Queries;
using Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.Mechanism
{
    public interface IGetMechanismsCommand : ICommand<MechanismQuery, PagedResponse<MechanismDto>>
    {
    }
}
