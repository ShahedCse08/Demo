using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Utility
{
    public class AutoCompleteItem<T>
    {
        public T Value { get; set; }
        public string Text { get; set; }
    }
}
