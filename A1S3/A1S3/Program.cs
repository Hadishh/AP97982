using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string resultPath = @"..\..\result.txt";
            string negWordsPath = @"..\..\TwitterData\Words\negative.txt";
            string posWordsPath = @"..\..\TwitterData\Words\positive.txt";
            string[] posWords = File.ReadAllLines(posWordsPath);
            string[] negWords = File.ReadAllLines(negWordsPath);
            string[] tweetFiles = Directory.GetFiles(@"..\..\TwitterData\Tweets");
            File.WriteAllText(resultPath, "");
            foreach (string tweetFile in tweetFiles)
            {
                string result = null;
                double charge = 0f;
                result = Path.GetFileNameWithoutExtension(tweetFile) + ":";
                string[] tweets = File.ReadAllLines(tweetFile);
                tweets[0] = "";
                charge = Q5_GetAvgPopChargeOfTweets(tweets, negWords, posWords);
                result = result + charge.ToString("0.000") + '\n';
                File.AppendAllText(resultPath, result);
            }
            return;
        }
        public static string[] Q1_GetWords(string path)
        {
            char[] delims = new char[] { '\n', '\r' };
            string[] words = File.ReadAllText(path).Split(delims, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
        public static bool Q2_IsInWords(string[] words, string word)
        {
            foreach (string item in words)
                if (item == word)
                    return true;
            return false;
        }
        public static string[] Q3_GetWordsOfTweet(string tweet)
        {
            char[] delims = new char[] { ' ', ';', '.', '@', '،', '/', '\\', '?', '؟', '#', ':', '"', '\'', '>', '<', '$', '*','(', ')',
                                         '[', ']', '{', '}', '=','+', '-', '!'};
            string[] words = tweet.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
        public static int Q4_GetPopChargeOfTweet(string tweet, string[] posWords, string[] negWords)
        {
            int charge = 0;
            string[] tweetWords = Q3_GetWordsOfTweet(tweet);
            foreach (string str in tweetWords)
                if (Q2_IsInWords(posWords, str))
                    charge++;
                else if (Q2_IsInWords(negWords, str))
                    charge--;
            return charge;
        }
        public static double Q5_GetAvgPopChargeOfTweets(string[] tweets, string[] negWords, string[] posWords)
        {
            double averageCharge = 0f;
            foreach (string tweet in tweets)
                averageCharge += Q4_GetPopChargeOfTweet(tweet, posWords, negWords);
            averageCharge /= (tweets.Length - 1);
            return averageCharge;
        }
    }

}
