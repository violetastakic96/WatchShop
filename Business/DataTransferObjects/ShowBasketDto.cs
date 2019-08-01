using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DataTransferObjects
{
    public class ShowBasketDto
    {
        public string Username { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
