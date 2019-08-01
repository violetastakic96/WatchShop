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
    public class EfAddMechanismCommand : EfBaseCommand, IAddMechanismCommand
    {
        public EfAddMechanismCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(MechanismDto request)
        {
            if (Context.Mechanisms.Any(m => m.Name == request.Name))
                throw new EntityAlreadyExistsException("Mechanism");

            Context.Mechanisms.Add(new Domain.Mechanism
            {
                Name = request.Name
            });

            Context.SaveChanges();
        }
    }
}
