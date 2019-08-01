using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Gender;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Gender
{
    public class EfAddGenderCommand : EfBaseCommand, IAddGenderCommand
    {
        public EfAddGenderCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(GenderDto request)
        {
            if (Context.Genders.Any(g => g.Name == request.Name))
                throw new EntityAlreadyExistsException("Gender");

            Context.Genders.Add(new Domain.Gender
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
