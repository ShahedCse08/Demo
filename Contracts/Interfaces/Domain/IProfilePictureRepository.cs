using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Domain
{
 public   interface IProfilePictureRepository
    {
        void CreateProfilePicture(UsersProfilePicture UsersProfilePicture);
        void DeleteProfilePicture(UsersProfilePicture UsersProfilePicture);
        Task<UsersProfilePicture> GetProfilePictureAsync(string userId, bool trackChanges);

    }
}
