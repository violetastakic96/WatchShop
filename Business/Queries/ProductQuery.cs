using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Queries
{
    public class ProductQuery : BaseQuery
    {
        public string Name { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public bool? Waterproof { get; set; }
        public bool? IsAvailable { get; set; }
        public int? MechanismId { get; set; }
        public int? GenderId { get; set; }
        public int? BrandId { get; set; }
    }
}
