using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Waterproof { get; set; }
        public int Warranty { get; set; }
        public int AvailCount { get; set; }
        public int MechanismId { get; set; }
        public int GenderId { get; set; }
        public int BrandId { get; set; }
        public Mechanism Mechanism { get; set; }
        public Gender Gender { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}
