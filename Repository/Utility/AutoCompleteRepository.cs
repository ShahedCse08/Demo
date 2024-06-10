using Contracts.Interfaces.Utility;
using Entities.Context;
using Entities.Models.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Utility
{
    public class AutoCompleteRepository : IAutoCompleteRepository
    {
        private readonly RepositoryContext _context;

        public AutoCompleteRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AutoCompleteItem<int>>> GetProductAutocompleteAsync(string query)
        {

            var queryNormalized = query.ToUpper();
            var products = await _context.Products
                .Where(x => x.Name.ToUpper().StartsWith(queryNormalized))
                .Select(c => new AutoCompleteItem<int>
                {
                    Value = c.ProductId,
                    Text = c.Name
                })
                .ToListAsync(); 
            return products;
        }
    }
}
