using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Email
{
    public class EmailContent
    {
        public int EmailContentId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string To { get; set; }

    }
}
