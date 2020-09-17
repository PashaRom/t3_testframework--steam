using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class MenuItem
    {
        private readonly string name;
        private readonly string locator;
        public MenuItem(string name, string locator)
        {
            this.name = name;
            this.locator = locator;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Locator
        {
            get
            {
                return locator;
            }
        }


    }
}
