using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
  public  class UsersProfilePicture
    {
        [Column("UserProfilePictureId")]
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string UserId { get; set; }
       
    }
}
