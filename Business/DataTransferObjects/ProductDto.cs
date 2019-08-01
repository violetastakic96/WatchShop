using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.DataTransferObjects
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Name should be minimum 3 and maximum 30 letters")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        [Required]
        public bool Waterproof { get; set; }
        [Required]
        public int Warranty { get; set; }
        [Required]
        public int AvailCount { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int MechanismId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int GenderId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int BrandId { get; set; }
    }
}
