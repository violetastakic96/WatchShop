using Business.DataTransferObjects;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.Basket
{
    public interface IGetUserBasketCommand : ICommand<int, IEnumerable<ShowBasketDto>>
    {
    }
}
