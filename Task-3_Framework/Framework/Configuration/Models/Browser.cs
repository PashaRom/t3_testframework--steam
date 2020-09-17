using System;
using System.Collections.Generic;
using System.Text;

namespace App.Framework.Configuration.Models
{
    public class BrowserOptions {
       
        public string PathToDriver { get; set; }
        public bool IsActive { get; set; }
        public Options Options { get; set; }
    }
}
