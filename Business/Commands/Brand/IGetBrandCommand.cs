using Business.DataTransferObjects;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.Brand
{
    public interface IGetBrandCommand : ICommand<int, BrandDto>
    {
    }
}
