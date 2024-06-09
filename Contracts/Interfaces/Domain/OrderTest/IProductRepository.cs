using Entities.Models.OrderTest;
using Entities.Models.PurchaseOrders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Domain.OrderTest
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
        Task<Product> GetProductAsync(int productId, bool trackChanges);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
