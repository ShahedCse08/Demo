﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Retrieve
{
    public class CompanyEmployeesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }



}