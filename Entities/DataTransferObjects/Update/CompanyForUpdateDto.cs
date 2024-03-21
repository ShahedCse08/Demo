using Entities.DataTransferObjects.Creation;
using Entities.DataTransferObjects.Manipulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Update
{
    public class CompanyForUpdateDto : CompanyFoManipulationDto
    {
        public string Country { get; set; }
        public IEnumerable<EmployeeForCreationDto> Employees { get; set; }
    }
}
