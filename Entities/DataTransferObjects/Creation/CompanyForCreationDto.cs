using Entities.DataTransferObjects.Manipulator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.Creation
{
  public  class CompanyForCreationDto : CompanyFoManipulationDto
    {

        public string Country { get; set; }
        public IEnumerable<EmployeeForCreationDto> Employees { get; set; }


    }
}
