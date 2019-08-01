using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Basket
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public int Quantity { get; set; }
    }
}
