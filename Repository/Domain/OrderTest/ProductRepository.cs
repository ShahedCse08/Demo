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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(p => p.Name)
                .ToListAsync();

        public async Task<Product> GetProductAsync(int productId, bool trackChanges) =>
            await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateProduct(Product product) => Create(product);

        public void DeleteProduct(Product product) => Delete(product);
    }
}
