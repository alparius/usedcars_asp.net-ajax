using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspweb_usedcars.Models
{
    public class Car
    {
        public int id { get; set; }
        public string model { get; set; }
        public int engine_power { get; set; }
        public string fuel { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public string category { get; set; }
    }
}