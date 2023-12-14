using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerOne.Models
{
    public class City
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public City() { }

        public City(long id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}