using Contracts.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repository
{
   public interface IRepositoryManager
    {
    
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IProfilePictureRepository ProfilePicture { get; }
        Task SaveAsync();
    }
}
