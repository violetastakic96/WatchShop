using System;
using System.Collections.Generic;
using System.Text;
using Business.Commands.Mechanism;
using Business.Exceptions;
using EfDataAccess;

namespace EfCommands.Mechanism
{
    public class EfDeleteMechanismCommand : EfBaseCommand, IDeleteMechanismCommand
    {
        public EfDeleteMechanismCommand(ShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var mechanism = Context.Mechanisms.Find(request);

            if (mechanism == null)
                throw new EntityNotFoundException("Mechanism");

            Context.Mechanisms.Remove(mechanism);
            Context.SaveChanges();
        }
    }
}
