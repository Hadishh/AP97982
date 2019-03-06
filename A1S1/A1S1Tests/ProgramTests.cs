using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void CaculateLengthTest()
        {
            Assert.AreEqual(5, Program.CaculateLength("12345"));
            Assert.AreEqual(0, Program.CaculateLength(""));
            Assert.AreEqual(22, Program.CaculateLength("abc,ddla123@#$%^&*sdeq"));
            Assert.AreEqual(3, Program.CaculateLength("abc"));
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            Assert.AreEqual(5, Program.LetterCount("A b c 1 2 3 d458f"));
            Assert.AreEqual(0, Program.LetterCount("01234567890"));
            Assert.AreEqual(11, Program.LetterCount(",134hadiSheikhi4567"));
            Assert.AreEqual(0, Program.LetterCount(""));
            Assert.AreEqual(32, Program.LetterCount("Hello World! This is a Test For Checking!"));
        }

        [TestMethod()]
        public void LineCountTest()
        {
            string[] Tests = new string[] {"", "\n", "\n\n", "Hello\n", "Hello",
                "Good\nbye\n" /*This Is Three Lines Ithink !*/, "Good Bye, ", "         "};
            Assert.AreEqual(0, Program.LineCount(Tests[0]));
            Assert.AreEqual(2, Program.LineCount(Tests[1]));
            Assert.AreEqual(3, Program.LineCount(Tests[2]));
            Assert.AreEqual(2, Program.LineCount(Tests[3]));
            Assert.AreEqual(1, Program.LineCount(Tests[4]));
            Assert.AreEqual(3, Program.LineCount(Tests[5]));
            Assert.AreEqual(1, Program.LineCount(Tests[6]));
            Assert.AreEqual(1, Program.LineCount(Tests[7]));

        }

        [TestMethod()]
        public void FileLineCountTest()
        {
            string filePath;
            int lineCount = 0, charCount;
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(lineCount, Program.FileLineCount(filePath));
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(lineCount, Program.FileLineCount(filePath));
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(lineCount, Program.FileLineCount(filePath));
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(lineCount, Program.FileLineCount(filePath));
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(lineCount, Program.FileLineCount(filePath));
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(lineCount, Program.FileLineCount(filePath));
        }
        
        [TestMethod()]
        public void ListFilesTest()
        {
            string filePath = null;
            string[] expectedFiles = GetTestDir(out filePath);
            string[] a = Program.ListFiles(filePath);
            //Array.Sort(a);
            if (expectedFiles.Length != a.Length)
                Assert.Fail();
            for(int i = 0; i < expectedFiles.Length; i++)
            {
                Assert.AreEqual(expectedFiles[i], a[i]);
            }
        }
        [TestMethod()]
        public void FileSizeTest()
        {
            string filePath;
            int lineCount = 0, charCount;
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(charCount, Program.FileSize(filePath));
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(charCount, Program.FileSize(filePath));
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(charCount, Program.FileSize(filePath));
            filePath = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(charCount, Program.FileSize(filePath));
        }
        private static string GetTestFile(out int lineCount, out int charCount)
        {
            charCount = 0;
            string tmpFile = Path.GetTempFileName();
            lineCount = new Random(0).Next(10, 100);
            List<string> lines = new List<string>();
            for (int i = 0; i < lineCount; i++)
            {
                string line = $"Line number {i}";
                //Because Of "\n\r" Cahracters When Write To file Adding to Line Length
                charCount += line.Length + 2;
                lines.Add(line);
            }
            File.WriteAllLines(tmpFile, lines);
            string a = File.ReadAllText(tmpFile);
            return tmpFile;
        }
        private static string[] GetTestDir(out string tmpDir)
        {
            tmpDir = Path.GetTempPath();
            Directory.CreateDirectory(tmpDir);
            int rndNum = new Random(0).Next(10, 20);
            List<string> files = new List<string>();
            for (int i = 0; i < rndNum; i++)
            {
                string fileName = Path.Combine(tmpDir, $"file{i}.txt");
                File.WriteAllText(fileName, $"file{i}.txt content");
                files.Add(fileName);
            }
            return files.ToArray();
        }
    }
}