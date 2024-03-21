using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.Auth
{
  public  class OtpValidatorDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string TwoFactorCode { get; set; }

        public bool RememberUser { get; set; }

        public bool RememberClient{ get; set; }

    }
}
