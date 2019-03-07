using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S3;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void Q1_GetWordsTest()
        {
            string path = CreateTmpFile();
            string[] fileLines1 = new string[] { "خوب", "بد", "متوسط", "عالی", "ضعیف", "خیلی خوب" };
            string[] fileLines2 = new string[] { };
            string[] fileLines3 = new string[] { "من", "شما", "او" };
            string[] fileLines4 = new string[] { "خوب", "بد", "متوسط", "عالی", "ضعیف", "خیلی خوب", "خوب", "بد", "متوسط", "عالی", "ضعیف", "خیلی خوب", "2", "من", "شما", "او" };
            File.WriteAllLines(path, fileLines1);
            CollectionAssert.AreEqual(fileLines1, Program.Q1_GetWords(path));
            File.WriteAllLines(path, fileLines2);
            CollectionAssert.AreEqual(fileLines2, Program.Q1_GetWords(path));
            File.WriteAllLines(path, fileLines3);
            CollectionAssert.AreEqual(fileLines3, Program.Q1_GetWords(path));
        }

        [TestMethod()]
        public void Q2_IsInWordsTest()
        {
            string[] words = new string[] { "کلمه", "همه", "یک", "امر", "علم", "ثروت" };
            Random rnd = new Random();
            Assert.AreEqual(true, Program.Q2_IsInWords(words, "همه"));
            Assert.AreEqual(false, Program.Q2_IsInWords(words, "امور"));
            Assert.AreEqual(false, Program.Q2_IsInWords(words, "نثار"));
            Assert.AreEqual(false, Program.Q2_IsInWords(words, ""));
            Assert.AreEqual(true, Program.Q2_IsInWords(words, words[rnd.Next(0, 5)]));
        }

        [TestMethod()]
        public void Q3_GetWordsOfTweetTest()
        {
            string tweet1 = "به نام خداوند بخشنده مهربان. امروز پنجم تیرماه سال جاری است.";
            string[] tweet1Words = new string[] { "به", "نام", "خداوند", "بخشنده", "مهربان", "امروز", "پنجم", "تیرماه", "سال", "جاری", "است" };
            CollectionAssert.AreEqual(tweet1Words, Program.Q3_GetWordsOfTweet(tweet1));
            string tweet2 = "ما هم اکنون در حال تست تمرین درس برنامه سازی پیشرفته هستیم. اینجا ! دانشگاه علم و صنعت ایران، آیا آماده هستید ؟";
            string[] tweet2Words = new string[] { "ما", "هم", "اکنون", "در", "حال", "تست", "تمرین", "درس", "برنامه", "سازی", "پیشرفته",
                                    "هستیم", "اینجا", "دانشگاه", "علم", "و", "صنعت", "ایران", "آیا", "آماده" , "هستید"};
            CollectionAssert.AreEqual(tweet2Words, Program.Q3_GetWordsOfTweet(tweet2));
        }

        [TestMethod()]
        public void Q4_GetPopChargeOfTweetTest()
        {
            string[] goodWords = new string[] { "خوب", "عالی", "مهربان", "زیبا", "خوش" };
            string[] badWords = new string[] { "بد", "ناخوش", "ناخوشایند", "زشت" };
            Random rndHandler = new Random();
            string tweet1 = "حال خوب و خوش خود را با حال بد و ناخوشایند یک انسان زشت و مهربان عوض نمیکنم! پس باید زشت و مهربان نباشیم بلکه زیبا باشیم و خوب:)";
            Assert.AreEqual(2, Program.Q4_GetPopChargeOfTweet(tweet1, goodWords, badWords));
            tweet1 = goodWords[rndHandler.Next(0, 4)] +  " " + goodWords[rndHandler.Next(0, 4)] + " " + 
                goodWords[rndHandler.Next(0, 4)] + " " + goodWords[rndHandler.Next(0, 4)] 
                + " " + badWords[rndHandler.Next(0, 4)];
            Assert.AreEqual(3, Program.Q4_GetPopChargeOfTweet(tweet1, goodWords, badWords));
        }

        [TestMethod()]
        public void Q5_GetAvgPopChargeOfTweetsTest()
        {
            string[] goodWords = new string[] { "خوب", "عالی", "مهربان", "زیبا", "خوش" };
            string[] badWords = new string[] { "بد", "ناخوش", "ناخوشایند", "زشت" };
            Random rndHandler = new Random();
            string tweet1 = goodWords[rndHandler.Next(0, 4)] + " " + goodWords[rndHandler.Next(0, 4)] + " " +
               goodWords[rndHandler.Next(0, 4)] + " " + goodWords[rndHandler.Next(0, 4)]
               + " " + badWords[rndHandler.Next(0, 4)];
            string[] tweets = new string[] { "متن اولیه توئیت که باید رد بشود مربوط به صاحب اکانت است!",
                "حال خوب و خوش خود را با حال بد و ناخوشایند یک انسان زشت و مهربان عوض نمیکنم! پس باید زشت و مهربان نباشیم بلکه زیبا باشیم و خوب"
                                        , tweet1};
            Assert.AreEqual(2.5f, Program.Q5_GetAvgPopChargeOfTweets(tweets, badWords, goodWords));
        }
        public string CreateTmpFile()
        {
            string path = Path.GetTempFileName();
            return path;
        }
    }
}