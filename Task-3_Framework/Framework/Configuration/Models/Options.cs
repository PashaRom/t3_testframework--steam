using System;
using System.Collections.Generic;
using System.Text;

namespace App.Framework.Configuration.Models
{
    public class Options {
        public string StartSizeWindow { get;set;}
        public bool LeaveBrowserRunning { get; set; }
        public string Mode { get; set; }
        public int ImplicitWait { get; set; }

    }
}
