﻿using Contracts.Interfaces.Domain;
using Entities;
using Entities.Context;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {


        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }


        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
            .Search(employeeParameters.SearchTerm)
            .OrderBy(e => e.Name)
            .Sort(employeeParameters.OrderBy)
            .ToListAsync();


            return PagedList<Employee>
            .ToPagedList(employees, employeeParameters.PageNumber,
            employeeParameters.PageSize);

        }


        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) => await
 FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id),
trackChanges)
 .SingleOrDefaultAsync();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);




    }
}
