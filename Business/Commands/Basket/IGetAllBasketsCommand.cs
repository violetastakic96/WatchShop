using Business.DataTransferObjects;
using Business.Interfaces;
using Business.Queries;
using Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.Basket
{
    public interface IGetAllBasketsCommand : ICommand<BasketQuery,PagedResponse<ShowBasketDto>>
    {
    }
}
