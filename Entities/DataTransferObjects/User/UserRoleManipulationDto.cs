using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.User
{
   public class UserRoleManipulationDto
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
