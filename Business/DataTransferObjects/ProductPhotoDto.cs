﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.DataTransferObjects
{
    public class ProductPhotoDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Alt { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
