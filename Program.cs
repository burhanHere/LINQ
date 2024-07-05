using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows.Markup;
using System.Security.Cryptography;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace LINQ
{
    public static class Program
    {
        private readonly static List<City> cities =
            [
                new("Tokyo", 37833000),
                new("Delhi", 30290000),
                new("Shanghai", 27110000),
                new("São Paulo", 22043000),
                new("Mumbai", 20412000),
                new("Beijing", 20384000),
                new("Cairo", 18772000),
                new("Dhaka", 17598000),
                new("Osaka", 19281000),
                new("New York-Newark", 18604000),
                new("Karachi", 16094000),
                new("Chongqing", 15872000),
                new("Istanbul", 15029000),
                new("Buenos Aires", 15024000),
                new("Kolkata", 14850000),
                new("Lagos", 14368000),
                new("Kinshasa", 14342000),
                new("Manila", 13923000),
                new("Rio de Janeiro", 13374000),
                new("Tianjin", 13215000)
            ];
        private static void CityDataSourceLinqWOrk()
        {
            //Cities and Population:
            //_______________________________________________________________________

            //Retrieve the names of cities with a population greater than 15 million.
            var q1Output = cities.Where(city => city.Population > 15000000).Select(city => city.Name);
            //or
            q1Output = (from city in cities
                        where city.Population > 15000000
                        select city.Name).ToList();
            foreach (var i in q1Output)
            {
                Console.WriteLine(i);
            }
            //_______________________________________________________________________

            //Find the total population of all cities.
            var q2Output = cities.Sum(city => city.Population);
            //or
            q2Output = (from city in cities
                        select city).Sum(city => city.Population);
            Console.WriteLine(q2Output);
            //_______________________________________________________________________

            //Get the top 5 most populous cities.
            var q3Output = (from city in cities
                            orderby city.Population descending
                            select city.Name).Take(5).ToList();
            //or
            q3Output = cities.OrderByDescending(city => city.Population).Select(City => City.Name).Take(5).ToList();
            foreach (var i in q3Output)
            {
                Console.WriteLine(i);
            }
            //_______________________________________________________________________

            //Find the average population of all cities.
            var q4Output = (from city in cities
                            select city.Population).Average();
            //or
            q4Output = cities.Average(city => city.Population);
            Console.WriteLine(q4Output);
        }

        private readonly static List<Country> countries =
            [
                new("Vatican City", 0.44, 526, [new("Vatican City", 826)]),
                new("Monaco", 2.02, 38000, [new("Monte Carlo", 38000)]),
                new("Nauru", 21, 10900, [new("Yaren", 1100)]),
                new("Tuvalu", 26, 11600, [new("Funafuti", 6_200)]),
                new("San Marino", 61, 33900, [new("San Marino", 4500)]),
                new("Liechtenstein", 160, 38000, [new("Vaduz", 5200)]),
                new("Marshall Islands", 181, 58000, [new("Majuro", 28000)]),
                new Country("Saint Kitts & Nevis", 261, 53000, [new("Basseterre", 13000)])
            ];
        private static void CountryDataSourceLinqWOrk()
        {
            //Countries and Metrics:
            //_______________________________________________________________________

            //Find the countries with a population density greater than 100 people per square kilometer.
            var q5Output = (from country in countries
                            where ((double)country.Population / (double)country.Area) > 100
                            select country.Name).ToList();
            //or
            q5Output = countries.Where(country => ((double)country.Population / (double)country.Area) > 100).Select(country => country.Name).ToList();
            foreach (var i in q5Output)
            {
                Console.WriteLine(i);
            }
            //_______________________________________________________________________

            //Get the names of countries sorted alphabetically.
            var q6Output = (from country in countries
                            orderby country.Name ascending
                            select country.Name).ToList();
            //or
            q6Output = countries.OrderBy(country => country.Name).Select(country => country.Name).ToList();
            foreach (var i in q6Output)
            {
                Console.WriteLine(i);
            }
            //_______________________________________________________________________

            //Calculate the total population of all countries.
            var q7Ouput = (from country in countries
                           select country.Population).Sum();
            //or
            q7Ouput = countries.Select(country => country).Sum(country => country.Population);
            Console.WriteLine(q7Ouput);
            //_______________________________________________________________________

            //Determine the country with the highest population.
            var q8output1 = (from country in countries
                             orderby country.Population descending
                             select country).ToList();
            Console.WriteLine(q8output1.First());
            //or
            var q8output2 = countries.OrderByDescending(country => country.Population).First();
            Console.WriteLine(q8output2);
            //or 
            var q8output3 = countries.MaxBy(country => country.Population);
            Console.WriteLine(q8output3);
            //_______________________________________________________________________

            //Combining Data:
            //_______________________________________________________________________

            //Find the top 3 most populous cities and their corresponding countries.
            var q9Output =
                (
                from country in countries
                from city in country.Cities
                orderby city.Population descending
                select new
                {
                    countryName = country.Name,
                    cityName = city.Name,
                    cityPopulation = city.Population
                }
                ).Take(3).ToList();
            //or
            q9Output = countries.SelectMany(
                country => country.Cities,
                (country, city) => new
                {
                    countryName = country.Name,
                    cityName = city.Name,
                    cityPopulation = city.Population,
                }).OrderByDescending(city => city.cityPopulation).Take(3).ToList();
            foreach (var city in q9Output)
            {
                Console.WriteLine($"Country: {city.countryName}, City: {city.cityName}, Population: {city.cityPopulation}");
            }
        }
        private readonly static List<Student> students =
            [
                new ("Alice", 16),
                new ("Frank", 19),
                new ("Emily", 21),
                new ("Grace", 15),
                new ("David", 14),
                new ("Charlie", 18),
                new ("Bob", 20),
                new ("Hannah", 17),
                new ("Isaac", 22),
                new ("Jack", 18),
                new ("Katherine", 16),
                new ("Liam", 20),
                new ("Megan", 19),
                new ("Nathan", 17),
                new ("Olivia", 18),
                new ("Patrick", 20),
                new ("Quinn", 16),
                new ("Andrew", 19),
                new ("Dylan", 18),
                new ("Ariana", 17),
                new ("Clara", 19),
                new ("Connor", 21),
                new ("April", 16),
                new ("Anthony", 22),
                new ("Eric", 17),
                new ("Christopher", 22),
                new ("Colton", 20),
            ];
        private static void StudnetDataSourceLinqWOrk()
        {
            //LINQ Queries:

            //Where: Given a list of students, filter out only the students who are teenagers(age between 13 and 19).
            //Query Syntax
            Console.WriteLine("output1:");
            var output1 = (from student in students
                           where student.Age >= 13 && student.Age <= 19
                           select student).ToList();
            //Method Syntex
            output1 = students.Where(student => student.Age >= 13 && student.Age <= 19).Select(student => student).ToList();
            foreach (var item in output1)
            {
                Console.WriteLine(item);
            }


            //OfType: Given a mixed list of objects, filter out only the objects that are of type "Student".
            //Query Syntax
            Console.WriteLine("output2:");
            var output2 = (from student in students
                           where student is Student
                           select student).ToList();
            //Method Syntex
            output2 = students.OfType<Student>().ToList();
            foreach (var item in output2)
            {
                Console.WriteLine(item);
            }

            //OrderBy: Given a list of students, order them by their names alphabetically.
            //Query Syntax
            Console.WriteLine("output3:");
            var output3 = (from student in students
                           orderby student.Name ascending
                           select student).ToList();
            //Method Syntex
            output3 = students.OrderBy(student => student.Name).Select(student => student).ToList();
            foreach (var item in output3)
            {
                Console.WriteLine(item);
            }

            //OrderByDescending: Given a list of students, order them by their names in descending alphabetical order.
            //Mixed Syntax
            Console.WriteLine("output4:");
            var output4 = (from student in students
                           select student).OrderByDescending(student => student.Name).ToList();
            //Method Syntex
            output4 = students.OrderByDescending(student => student.Name).Select(student => student).ToList();
            foreach (var item in output4)
            {
                Console.WriteLine(item);
            }

            //ThenBy: Given a list of students, order them by their names alphabetically and then by age.
            //Mixed Syntax
            Console.WriteLine("output5:");
            var output5 = (from student in students
                           orderby student.Name ascending
                           select student).ThenBy(student => student.Age).ToList();
            //Method Syntex
            output5 = students.OrderBy(student => student.Name).ThenBy(student => student.Age).Select(student => student).ToList();
            foreach (var item in output5)
            {
                Console.WriteLine(item);
            }

            //ThenByDescending: Given a list of students, order them by their names alphabetically and then by age in descending order.
            //Mixed Syntax
            Console.WriteLine("output6:");
            var output6 = (from student in students
                           orderby student.Name ascending
                           select student).ThenByDescending(student => student.Age).ToList();
            //Method Syntex
            output6 = students.OrderBy(student => student.Name).ThenByDescending(student => student.Age).Select(student => student).ToList();
            foreach (var item in output6)
            {
                Console.WriteLine(item);
            }

            //Reverse: Given a list of students, reverse the order of students.
            //Mixed Syntax
            var output7 = (from student in students
                           select student).Reverse().ToList();
            //Method Syntex
            output7 = students.Select(student => student).Reverse().ToList();
            foreach (var item in output7)
            {
                Console.WriteLine(item);
            }

            //All: Given a list of students, check if all students are teenagers(age between 13 and 19).
            //Mixed Syntax
            var output8 = (from student in students
                           select student).All(student => student.Age >= 13 && student.Age <= 19);
            //Method Syntex
            output8 = students.All(student => student.Age >= 13 && student.Age <= 19);
            Console.WriteLine(output8);

            //Any: Given a list of students, check if there is any student who is a teenager (age between 13 and 19).
            //Mixed Syntax
            var output9 = (from student in students
                           select student).Any(student => student.Age >= 13 && student.Age <= 19);
            //Method Syntex
            output9 = students.Any(student => student.Age >= 13 && student.Age <= 19);
            Console.WriteLine(output9);

            //Contains: Given a list of students, check if the list contains a specific student.
            //Query Syntax
            StudentComparer comparer = new();
            var output = (from student in students
                          select student).Contains(new Student("Hannah", 17));//returns false before implimentation of IEqualityComparer because it is comparing refrences of the two objects
            Console.WriteLine(output);
            output = (from student in students
                      select student).Contains(new Student("Hannah", 17), comparer); //after implimentation of IEqualityComparer it compairs the hashcodes and values of the object propertiesand returns true if that exixts
            Console.WriteLine(output);
            //Method Syntex
            output = students.Contains(new Student("Hannah", 17));//returns false before implimentation of IEqualityComparer because it is comparing refrences of the two objects
            Console.WriteLine(output);
            output = students.Contains(new Student("Hannah", 17), comparer); //after implimentation of IEqualityComparer it compairs the hashcodes and values of the object propertiesand returns true if that exixts
            Console.WriteLine(output);
        }

        private readonly static List<Person> people1 = [
        new (1, "Alice", 25 ),
        new (2, "Bob", 30 ),
        new (3, "Charlie", 22 ),
        new (4, "David", 35 ),
        new (5, "Eve", 28 ),
        new (6, "Frank", 32 ),
        new (7, "Alice", 27 ), // Duplicate name
        ];
        private readonly static List<Person> people2 = [
        new (8, "Alice", 29 ),
        new (9, "Gary", 31 ),
        new (10, "Helen", 26 ),
        new (11, "Bob", 29 ),
        new (12, "Frank", 35 ),
        new (13, "Isabel", 27 ),
        new (14, "Alice", 22 ), // Duplicate name
        ];
        public static void PersonDataSourceLinqWOrk()
        {
            //LINQ Queries:

            //Distinct(): Retrieve a list of distinct names from the Person collection where names are sorted alphabetically.

            //method Syntax
            var output1 = people1.Select(person => person.Name).Distinct().ToList();
            //mixed Syntax
            output1 = (from person in people1
                       select person.Name).Distinct().ToList();
            foreach (var item in output1)
            {
                Console.WriteLine(item);
            }

            //Except(): Create a list of people who are not in a specified second list and whose age is greater than 25.

            //method Syntax
            var output2 = people1.Where(person => person.Age > 25)
                .Select(person => person.Name)
                .Except(people2.Where(person => person.Age > 25)
                                .Select(person => person.Name))
                .ToList();
            //// implimented IEquitable<T> interfacse alter natveis to create a custome class and impliment IEqualityComparer<T> interface, where in this case (T) is (Perosn).
            //mixed Syntax
            output2 = (from person in people1
                       where person.Age > 25
                       select person.Name).Except(from person in people2
                                                  where person.Age > 25
                                                  select person.Name).ToList();
            foreach (var item in output2)
            {
                Console.WriteLine(item);
            }

            //Intersect(): Find common elements between two lists where the name starts with 'A' and the age is less than 30.

            //methods Syntax
            var output3 = people1.Where(person => person.Age < 30 && person.Name.StartsWith('A')).
                                    Select(person => person.Name)
                        .Intersect(people2.Where(person => person.Age < 30 && person.Name.StartsWith('A')).Select(person => person.Name)).ToList();
            ////mixed Syntax
            output3 = (from person in people1
                       where person.Age < 30
                       select person.Name).Intersect(from person in people2
                                                     where person.Age < 30
                                                     select person.Name).ToList();
            foreach (var item in output3)
            {
                Console.WriteLine(item);
            }

            //Union(): Merge two lists and remove duplicates, retaining the original order of appearance.
            //methods Syntax
            var output4 = people1.Union(people2).ToList();
            ////mixed Syntax
            output4 = (from person in people1
                       select person).Union(from person in people2
                                            select person).ToList();
            foreach (var item in output4)
            {
                Console.WriteLine(item);
            }


            //Take(): Retrieve the first 3 people whose names are not duplicates.
            // method syntax
            var output5 = people1.GroupBy(person => person.Name)
                    .Where(group => group.Count() == 1)
                    .SelectMany(group => group.Take(1))
                    .Take(3)
                    .ToList();
            ////mixed Syntax
            output5 = (from person in people1
                       select person).GroupBy(person => person.Name).Where(group => group.Count() == 1).SelectMany(group => group.Take(1)).Take(3).ToList();
            foreach (var item in output5)
            {
                Console.WriteLine(item);
            }

            //TakeWhile(): Retrieve elements from the Person collection until a condition is no longer met(e.g., retrieve people older than 25 and stop at the first person younger than 30).
            // method syntax
            var output6 = people1.TakeWhile(person => person.Age > 30).ToList();
            //// mixed syntax
            output6 = (from person in people1
                       select person).TakeWhile(person => person.Age > 30).ToList();
            foreach (var item in output6)
            {
                Console.WriteLine(item);
            }

            //Skip(): Skip the first 2 people whose names are duplicates and retrieve the rest.
            // method syntax
            var output7 = people1.GroupBy(person => person.Name).Where(group => group.Count() == 1).SelectMany(group => group.Take(1)).Skip(2).ToList();
            // mixed syntax
            output7 = (
            from person in people1
            group person by person.Name into grouped
            where grouped.Count() == 1
            from person in grouped.Take(1)
            select person
            ).Skip(2).ToList();
            foreach (var item in output7)
            {
                Console.WriteLine(item);
            }

            //SkipWhile(): Skip elements from the Person collection while a condition is true(e.g., skip people younger than 25 and stop at the first person older than 30).
            // method syntax
            var output8 = people1.SkipWhile(person => person.Age < 30).ToList();
            //// mixed syntax
            output8 = (from person in people1
                       select person).SkipWhile(person => person.Age < 30).ToList();
            foreach (var item in output8)
            {
                Console.WriteLine(item);
            }
        }
        public static void Main(string[] args)
        {

            //Random question from chatGpt
            //CityDataSourceLinqWOrk();
            //_______________________________________________________________________
            //_______________________________________________________________________
            //_______________________________________________________________________
            //Random question from chatGpt
            //CountryDataSourceLinqWOrk();
            //_______________________________________________________________________
            //_______________________________________________________________________
            //_______________________________________________________________________
            // practice after proper understanding of (where(), Oftype(),Order(),Orderby(),OrderByDecending(),ThenBy(),ThenByDecending(),Reverse(),All(), Any(), Conatin())
            //StudnetDataSourceLinqWOrk();
            //_______________________________________________________________________
            //_______________________________________________________________________
            //_______________________________________________________________________
            // practice after proper understanding of (Distinct(), Except(), Intersect(), Union(), Take(), TakeWhile(), Skip(), SkipWhile(), pagging using skip()/take())
            //PersonDataSourceLinqWOrk();
            //_______________________________________________________________________
            //_______________________________________________________________________
            //_______________________________________________________________________
            var obj = new PractiecQuestionsFromW3Resource();
            obj.Test();

        }
    }
}
