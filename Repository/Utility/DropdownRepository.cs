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
    public class DropdownRepository : IDropdownRepository
    {

        private readonly RepositoryContext _context;

        public DropdownRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DropdownItem<int>>> GetSuppliersDropdownAsync()
        {
            return await _context.Suppliers
                .Select(c => new DropdownItem<int>
                {
                    Value = c.SupplierId,
                    Text = c.Name
                })
                .ToListAsync();
        }

    }
}
