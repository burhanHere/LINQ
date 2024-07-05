using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Country
    {
        private string name;
        private double area;
        private long population;
        private List<City> cities;

        public string Name { get { return name; } set { name = value; } }
        public double Area { get { return area; } set { area = value; } }
        public long Population { get { return population; } set { population = value; } }
        public List<City> Cities { get { return cities; } set { cities = value; } }

        public Country(string inputName, double inputArea, long inputPopulation, List<City> inputCities)
        {
            this.name = inputName;
            this.area = inputArea;
            this.population = inputPopulation;
            this.cities = inputCities;
        }

        public override string ToString()
        {
            string citiesInfo = string.Join(", ", Cities);
            return $"Country: {Name}, Area: {Area}, Population: {Population}, Cities: [{citiesInfo}]";
        }
    }
}
