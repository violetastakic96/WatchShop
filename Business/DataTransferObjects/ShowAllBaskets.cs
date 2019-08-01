using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DataTransferObjects
{
    public class ShowAllBaskets
    {
        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public List<ShowBasketDto> BasketDetail { get; set; }
    }
}
