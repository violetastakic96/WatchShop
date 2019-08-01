using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DataTransferObjects
{
    public class ShowProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Waterproof { get; set; }
        public int Warranty { get; set; }
        public int AvailCount { get; set; }
        public string Mechanism { get; set; }
        public string Gender { get; set; }
        public string Brand { get; set; }
        public List<ProductPhotoDto> ProductPhotos { get; set; }
    }
}
