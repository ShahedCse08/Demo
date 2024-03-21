using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.User
{
  public  class UserForManipulationDto
    {
       
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
       
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }

    }
}
