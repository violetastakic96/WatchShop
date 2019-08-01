using Business.DataTransferObjects;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.Gender
{
    public interface IAddGenderCommand : ICommand<GenderDto>
    {
    }
}
