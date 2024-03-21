using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Role
{
  public class RoleForUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
