using Business.Commands.Mechanism;
using Business.DataTransferObjects;
using Business.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Mechanism
{
    public class EfGetMechanismCommand : EfBaseCommand, IGetMechanismCommand
    {
        public EfGetMechanismCommand(ShopContext context) : base(context)
        {
        }

        public MechanismDto Execute(int request)
        {
            var mechanism = Context.Mechanisms.Find(request);

            if (mechanism == null)
                throw new EntityNotFoundException("Mechanism");

            return new MechanismDto
            {
                Id = mechanism.Id,
                Name = mechanism.Name
            };
        }
    }
}
