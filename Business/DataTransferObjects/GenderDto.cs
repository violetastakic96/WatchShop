using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.DataTransferObjects
{
    public class GenderDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Name should be minimum 3 and maximum 15 letters")]
        public string Name { get; set; }
    }
}
