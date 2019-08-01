using System;
using System.Collections.Generic;
using System.Text;
using Business.Commands.Gender;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Gender
{
    public class EfDeleteGenderCommand : EfBaseCommand, IDeleteGenderCommand
    {
        public EfDeleteGenderCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var gender = Context.Genders.Find(request);

            if (gender == null)
                throw new EntityNotFoundException("Gender");

            Context.Genders.Remove(gender);
            Context.SaveChanges();
        }
    }
}
