using System;
namespace E2
{
    public abstract class Person
    {
        public bool IsFemale { get; set; }
        protected string _Name;
        public abstract int LunchRate { get; }
        public virtual string Name {
            get => (IsFemale ? "خانم " : "آقای ") + _Name;
            protected set
            {
                if (value == null || value == string.Empty)
                    throw new ArgumentException();
                _Name = value;
            }
        }
        public Person(string name, bool isFemale)
        {
            Name = name;
            IsFemale = isFemale;
        }
    }

    public class Student : Person
    {
        public Student(string name, bool isFemale)
            :base(name, isFemale) { }
        public override int LunchRate => 2000;
    }

    public class Employee : Person
    {
        public Employee(string name, bool isFemale)
            :base (name, isFemale) { }
        public override int LunchRate => 5000;
        public virtual int CalculateSalary(int hours) => hours * 5000;
    }

    public class Teacher: Employee
    {
        public Teacher(string name, bool isFemale)
            :base (name, isFemale) { }
        public override string Name {
            get => "استاد "  + _Name;
            protected set => base.Name = value;
        }
        public override int LunchRate => 10_000;
        public override int CalculateSalary(int hours) => hours * 20_000;
    }
}