using Contracts.Interfaces.Domain;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain
{
    public class ProfilePictureRepository : RepositoryBase<UsersProfilePicture>, IProfilePictureRepository
    {
        public ProfilePictureRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateProfilePicture(UsersProfilePicture usersProfilePicture)
        {
            Create(usersProfilePicture);
        }

        public void DeleteProfilePicture(UsersProfilePicture usersProfilePicture)
        {
            Delete(usersProfilePicture);
        }

        public async Task<UsersProfilePicture> GetProfilePictureAsync(string userId, bool trackChanges)
        {
           return await FindByCondition(c => c.Id.Equals(userId), trackChanges).SingleOrDefaultAsync();
        }

          
    }
}
