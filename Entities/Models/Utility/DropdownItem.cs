using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Utility
{
    public class DropdownItem<T>
    {
        public T Value { get; set; }
        public string Text { get; set; }
    }
}
