using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class City
    {
        private string name;
        private long population;
        public string Name { get { return name; } set { name = value; } }
        public long Population { get { return population; } set { population = value; } }

        public City(string inputName, long inputPopulation)
        {
            this.name = inputName;
            this.population = inputPopulation;
        }

        public override string ToString()
        {
            return $"City: {Name}, Population: {Population}";
        }
    }
}
