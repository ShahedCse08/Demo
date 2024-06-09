using Entities.Models.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Utility
{
    public interface IDropdownRepository
    {
        Task<IEnumerable<DropdownItem<int>>> GetSuppliersDropdownAsync();
    }
}
