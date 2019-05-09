using Microsoft.VisualStudio.TestTools.UnitTesting;
using A8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8.Tests
{
    [TestClass()]
    public class HumanTests
    {
        [TestMethod()]
        public void HumanTest()
        {
            string expectedName = "Amir";
            string expectedLastName = "Amiri";
            double expectedHeight = 2.5;
            DateTime birthDate = new DateTime(2010, 9, 3);
            Human dwarf = new Human(expectedName, expectedLastName, birthDate, expectedHeight);
            Assert.AreEqual(expectedName, dwarf.FirstName);
            Assert.AreEqual(expectedLastName, dwarf.LastName);
            Assert.AreEqual(expectedHeight, dwarf.Height);
            Assert.IsTrue(dwarf.BirthDate.CompareTo(birthDate) == 0);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Human dwarf = new Human("Amir", "Amiri", new DateTime(2010, 9, 3), 2.5);
            Human ladder = new Human("Big", "Khan", new DateTime(2010, 9, 30), 12345);
            Assert.IsTrue(dwarf.Equals(dwarf));
            Assert.IsFalse(dwarf.Equals(null));
            Assert.IsFalse(dwarf.Equals(ladder));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            const int expectedHash = 93033477;
            Human dwarf = new Human("Amir", "Amiri", new DateTime(2010, 9, 3), 2.5);
            Assert.AreEqual(expectedHash, dwarf.GetHashCode());
        }
        [TestMethod()]
        public void PlusOperatorTest()
        {
            const string expectedFirstName = "ChildFirstName";
            const string expectedLastName = "ChildLastName";
            const double expectedHeight = 30.0;
            DateTime now = DateTime.Now;
            Human dwarf = new Human("Amir", "Amiri", new DateTime(2010, 9, 3), 2.5);
            Human ladder = new Human("Big", "Khan", new DateTime(2010, 9, 30), 12345);
            Human middlePerson = dwarf + ladder;
            Assert.AreEqual(expectedFirstName, middlePerson.FirstName);
            Assert.AreEqual(expectedLastName, middlePerson.LastName);
            Assert.AreEqual(expectedHeight, middlePerson.Height);
            Assert.AreEqual(now.Year, middlePerson.BirthDate.Year);
            Assert.AreEqual(now.Month, middlePerson.BirthDate.Month);
            Assert.AreEqual(now.Day, middlePerson.BirthDate.Day);
            Assert.AreEqual(now.Hour, middlePerson.BirthDate.Hour);
            Assert.AreEqual(now.Minute, middlePerson.BirthDate.Minute);
        }
        [TestMethod()]
        public void CompareOperatorsTest()
        {
            Human dwarf = new Human("Amir", "Amiri", new DateTime(2010, 9, 3), 2.5);
            Human dwarf2 = dwarf;
            Human ladder = new Human("Big", "Khan", new DateTime(2010, 9, 30), 12345);
            Human middlePerson = new Human("NewName", "NewLastName", new DateTime(2009, 2, 1), 160);
            Assert.IsTrue(dwarf < middlePerson);
            Assert.IsFalse(dwarf > middlePerson);
            Assert.IsTrue(dwarf == dwarf2);
            Assert.IsFalse(dwarf == ladder);
            Assert.IsTrue(dwarf <= dwarf2);
            Assert.IsFalse(dwarf >= middlePerson);
            Assert.IsTrue(ladder <= dwarf);
            Assert.IsTrue(dwarf != ladder);
        }
    }
}