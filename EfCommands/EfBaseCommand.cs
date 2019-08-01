using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfBaseCommand
    {
        protected ShopContext Context { get; }

        public EfBaseCommand(ShopContext context) => Context = context;

    }
}
