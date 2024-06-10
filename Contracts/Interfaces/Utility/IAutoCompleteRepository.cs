using Entities.Models.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Utility
{
    public interface IAutoCompleteRepository
    {
        Task<IEnumerable<AutoCompleteItem<int>>> GetProductAutocompleteAsync(string query);
    }
}
