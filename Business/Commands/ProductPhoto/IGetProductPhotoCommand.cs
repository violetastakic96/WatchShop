using Business.DataTransferObjects;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Commands.ProductPhoto
{
    public interface IGetProductPhotoCommand : ICommand<int,ShowProductPhoto>
    {
    }
}
