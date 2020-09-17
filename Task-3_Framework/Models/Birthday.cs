using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Birthday
    {
        public Birthday(int day, string mounth, int year) {
            Day = day;
            Mounth = mounth;
            Year = year;
        }
        public int Day { get; set; }
        public string Mounth { get; set; }
        public int Year { get; set; }
    }
}
