using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class AgePlace
    {

        public AgePlace(int Age,string Place)
        {
            this.Age = Age;
            this.Place = Place;
        }
        public int Age { get; set; }

        public string Place { get; set; }
    }
    class ClsPerson
    {
        public ClsPerson(string Name,AgePlace Age_Place)
        {
            this.Name = Name;
            this.Age_Place = Age_Place;
        }
        public string Name { get; set; }

        public AgePlace Age_Place { get; set; }

    }
}
