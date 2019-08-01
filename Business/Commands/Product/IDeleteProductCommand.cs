using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.Product
{
    public interface IDeleteProductCommand : ICommand<int>
    {
    }
}
