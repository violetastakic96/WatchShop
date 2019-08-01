using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Gender : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
