using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Username should be minimum 8 and maximum 20 letters")]
        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Firstname should be minimum 3 and maximum 20 letters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Lastname should be minimum 4 and maximum 25 letters")]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
