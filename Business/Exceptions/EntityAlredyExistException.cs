using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string entityType)
            : base(entityType + " already exists.")
        {

        }
    }
}
