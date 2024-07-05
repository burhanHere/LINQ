using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Student
    {
        private string name;
        private int age;
        public string Name { get { return this.name; } set { this.name = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }

        public Student(string inputName, int inputAge)
        {
            this.name = inputName;
            this.age = inputAge;
        }

        public override string ToString()
        {
            return $"Name: {this.name}, Age: {this.age}";
        }
    }

    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            else if (x is null || y is null)// or we can write (object.ReferenceEquals(x, null) && object.ReferenceEquals(y, null))
            {
                return false;
            }
            else
            {
                return x.Name == y.Name && x.Age == y.Age;
            }

        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            if (obj is null)// or we can write object.ReferenceEquals(obj, null)
            {
                return 0;
            }
            return obj.Name.GetHashCode() ^ obj.Age.GetHashCode();
        }
    }
}