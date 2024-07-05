using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Person : IEquatable<Person>
    {
        private int id;
        private string name;
        private int age;
        public int Id { get { return this.id; } set { this.id = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
        public Person(int inputId, string inputName, int inputAge)
        {
            this.id = inputId;
            this.name = inputName;
            this.age = inputAge;
        }
        public override string ToString()
        {
            return $"Id: {this.id}, Name: {this.name}, Age: {this.age}";
        }

        public bool Equals(Person? other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            else if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            else
            {
                return this.id == other.id && this.name == other.name && this.age == other.age;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Age);
        }
    }
}
