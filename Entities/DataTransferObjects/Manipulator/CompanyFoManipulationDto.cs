﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.Manipulator
{
  public abstract  class CompanyFoManipulationDto
    {

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for rhe Address is 60 characte")]
        public string Address { get; set; }
    }
}
