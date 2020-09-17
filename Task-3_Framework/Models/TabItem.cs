using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class TabItem : MenuItem
    {
        public TabItem(string name, string locator) : base(name, locator) { }
    }
}
