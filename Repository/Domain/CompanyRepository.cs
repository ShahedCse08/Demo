using Contracts.Interfaces.Domain;
using Entities;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) =>
    await FindAll(trackChanges)
    .OrderBy(c => c.Name)
    .ToListAsync();


        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
         await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
         .SingleOrDefaultAsync();

        public async Task<Company> GetCompanyWithChildListAsync(Guid companyId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(companyId), trackChanges).Include(x=>x.Employees)
        .SingleOrDefaultAsync();

        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool
        trackChanges) =>
         await FindByCondition(x => ids.Contains(x.Id), trackChanges)
         .ToListAsync();




        public void CreateCompany(Company company) => Create(company);



        public void DeleteCompany(Company company) => Delete(company);

        

    }
}
