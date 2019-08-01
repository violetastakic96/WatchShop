using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Commands.Mechanism;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Mechanism
{
    public class EfEditMechanismCommand : EfBaseCommand, IEditMechanismCommand
    {
        public EfEditMechanismCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(MechanismDto request)
        {
            var mechanism = Context.Mechanisms.Find(request.Id);

            if (mechanism == null)
                throw new EntityNotFoundException("Mechanism");

            if (request.Name != mechanism.Name && Context.Roles.Any(m => m.Name == request.Name))
                throw new EntityAlreadyExistsException("Mechanism");

            mechanism.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
