using System;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTest
{
    [TestClass]
    public class PrivacyScrubberTest 
    {
        [TestMethod]
        public void SinglePhoneNumberTest()
        {
            string piiNum = "(517)303-5279";
            string scrubbedPII = "(XXX)XXX-XXXX";
            string testString = $"My phone number is {piiNum}";
            string scrubbedString = $"My phone number is {scrubbedPII}";
            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void MultiplePhoneNumbersTest()
        {
            string pii1 = "(517)303-5279";
            string pii2 = "206-323-1212";
            string scrubbedPII1 = "(XXX)XXX-XXXX";
            string scrubbedPII2 = "XXX-XXX-XXXX";
            string testString = $"My phone number was {pii1} but it is {pii2} now";
            string scrubbedString = $"My phone number was {scrubbedPII1} but it is {scrubbedPII2} now";

            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void IDTest()
        {
            string testString = "Ali's SSN is  432-12-3232";
            string expectedString = "Ali's SSN is  XXX-XX-XXXX";
            string test1 = "Hadi's SSN is 127317734-7";
            string excepted1 = "Hadi's SSN is XXXXXXXXX-X";
            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);
            scrubbedString = IDScrubber.Instance.Scrub(test1);
            Assert.AreEqual(excepted1, scrubbedString);
        }

        [TestMethod]
        public void FullNameTest()
        {
            string testString = "Mr. Bill Gates failed the exam.";
            string expectedString = "Xx. Xxxx Xxxxx failed the exam.";

            string maskedString = FullNameScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);
        }

        [TestMethod]
        public void EmailTest()
        {
            string testString = "Maria's Email is Maria@gmail.com";
            string expectedString = "Maria's Email is Xxxxx.xxxxx.xxx";
            string scrubbedString = EmailScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, scrubbedString);
            testString = "Maria's Second Email is MArria@mit.edu";
            expectedString = "Maria's Second Email is XXxxxx.xxx.xxx";
            scrubbedString = EmailScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, scrubbedString);
        }

        [TestMethod]
        public void CCTest()
        {
            string testString = "Hadi's Card Nubmer is 6037-9975-4326-5665 Send Him Money :)";
            string expectedString = "Hadi's Card Nubmer is XXXX-XXXX-XXXX-XXXX Send Him Money :)";
            string scrubbedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, scrubbedString);
            testString = "Maria's Master Card Number is 5500-0000-0000-0004";
            expectedString = "Maria's Master Card Number is XXXX-XXXX-XXXX-XXXX";
            scrubbedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, scrubbedString);
        }
    }

}
