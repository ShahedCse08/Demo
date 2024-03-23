using Contracts.Interfaces.Domain.OrderTest;
using Entities.Context;
using Entities.Models.OrderTest;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.OrderTest
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Customer> GetCustomerAsync(int customerId, bool trackChanges) =>
            await FindByCondition(c => c.CustomerId.Equals(customerId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateCustomer(Customer customer) => Create(customer);

        public void DeleteCustomer(Customer customer) => Delete(customer);
    }
}
