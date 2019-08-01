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
    public class EfEditGenderCommand : EfBaseCommand, IEditGenderCommand
    {
        public EfEditGenderCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(GenderDto request)
        {
            var gender = Context.Genders.Find(request.Id);

            if (gender == null)
                throw new EntityNotFoundException("Gender");

            if (request.Name != gender.Name && Context.Roles.Any(g => g.Name == request.Name))
                throw new EntityAlreadyExistsException("Gender");

            gender.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
