using Entities.DataTransferObjects.Retrieve;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
  public class CompanyWithDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; }



        public CompanyWithDetails(Company company)
        {
            Id = company.Id;
            Name = company.Name;
            FullAddress = company.Address + company.Country;
        }

        public CompanyWithDetails(Task<Company> task)
        {
          
        }
    }
}
