using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalManagmentSystem
{
    public class Animal
    {
        public string name { get; set; }
        public string animalSpecie { get; set; }
        public int age { get; set; }
        public int stock { get; set; }
        public Dictionary<string, string> specialAttributes { get; set; }
    }
}
