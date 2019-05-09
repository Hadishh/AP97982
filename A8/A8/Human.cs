using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; }
        public double Height { get; set; }
        public Human(string firstName, string lastName, DateTime birthDate, double height)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Height = height;
        }
        public static Human operator + (Human h1, Human h2) {
            string firstName = "ChildFirstName";
            string lastName = "ChildLastName";
            double height = 30.0;
            DateTime birthDate = DateTime.Now;
            return new Human(firstName, lastName, birthDate, height);
        }
        public override bool Equals(object obj)
        {
            Human other = obj as Human;
            if (other is null)
                return false;
            bool isEqual = this.FirstName == other.FirstName && 
                this.LastName == other.LastName &&
                this.BirthDate.CompareTo(other.BirthDate) == 0 && 
                this.Height == other.Height;
            return isEqual;
        }
        public override int GetHashCode()
        {
            int hash = FirstName.GetHashCode() ^ LastName.GetHashCode();
            hash = hash ^ BirthDate.GetHashCode() ^ Height.GetHashCode();
            return hash;
       }
        public static bool operator <(Human h1, Human h2) 
            => h1.BirthDate.CompareTo(h2.BirthDate) > 0;
        public static bool operator >(Human h1, Human h2)
            => h1.BirthDate.CompareTo(h2.BirthDate) < 0;
        public static bool operator ==(Human h1, Human h2)
        {
            if (h1 is null || h2 is null)
                return false;
            return h1.BirthDate.CompareTo(h2.BirthDate) == 0;
        }
        public static bool operator !=(Human h1, Human h2) => !(h1 == h2);
        public static bool operator <=(Human h1, Human h2) => (h1 < h2) || h1 == h2;
        public static bool operator >=(Human h1, Human h2) => (h1 > h2) || h1 == h2;
        
    }
}
