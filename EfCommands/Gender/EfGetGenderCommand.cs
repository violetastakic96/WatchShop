using System;
using System.Collections.Generic;
using System.Text;
using Business.Commands.Gender;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Gender
{
    public class EfGetGenderCommand : EfBaseCommand, IGetGenderCommand
    {
        public EfGetGenderCommand(ShopContext context) : base(context)
        {
        }

        public GenderDto Execute(int request)
        {
            var gender = Context.Genders.Find(request);

            if (gender == null)
                throw new EntityNotFoundException("Gender");

            return new GenderDto
            {
                Id = gender.Id,
                Name = gender.Name
            };
        }
    }
}
