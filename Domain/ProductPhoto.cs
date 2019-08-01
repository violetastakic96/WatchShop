using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ProductPhoto : BaseEntity
    {
        public string Alt { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
