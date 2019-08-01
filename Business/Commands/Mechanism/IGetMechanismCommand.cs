using Business.DataTransferObjects;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.Mechanism
{
    public interface IGetMechanismCommand : ICommand<int, MechanismDto>
    {
    }
}
