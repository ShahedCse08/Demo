﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Retrieve
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string FullAddress { get; set; }
        public string Address { get; set; }

    }
}
