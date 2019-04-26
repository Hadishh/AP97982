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
            const int assert1 = 5;
            const int assert2 = 0;
            const int assert3 = 22;
            const int assert4 = 3;
            Assert.AreEqual(assert1, Program.CaculateLength("12345"));
            Assert.AreEqual(assert2, Program.CaculateLength(""));
            Assert.AreEqual(assert3, Program.CaculateLength("abc,ddla123@#$%^&*sdeq"));
            Assert.AreEqual(assert4, Program.CaculateLength("abc"));
            return;
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            const int assert1 = 5;
            const int assert2 = 0;
            const int assert3 = 11;
            const int assert4 = 0;
            const int assert5 =32;
            Assert.AreEqual(assert1, Program.LetterCount("A b c 1 2 3 d458f"));
            Assert.AreEqual(assert2, Program.LetterCount("01234567890"));
            Assert.AreEqual(assert3, Program.LetterCount(",134hadiSheikhi4567"));
            Assert.AreEqual(assert4, Program.LetterCount(""));
            Assert.AreEqual(assert5, Program.LetterCount("Hello World! This is a Test For Checking!"));
            return;
        }

        [TestMethod()]
        public void LineCountTest()
        {
            string[] Tests = new string[] {"", "\n", "\n\n", "Hello\n", "Hello",
                "Good\nbye\n" /*This Is Three Lines Ithink !*/, "Good Bye, ", "         "};
            const int assert1 = 0;
            const int assert2 = 2;
            const int assert3 = 3;
            const int assert4 = 2;
            const int assert5 = 1;
            const int assert6 = 3;
            const int assert7 = 1;
            const int assert8 = 1;
            Assert.AreEqual(assert1, Program.LineCount(Tests[0]));
            Assert.AreEqual(assert2, Program.LineCount(Tests[1]));
            Assert.AreEqual(assert3, Program.LineCount(Tests[2]));
            Assert.AreEqual(assert4, Program.LineCount(Tests[3]));
            Assert.AreEqual(assert5, Program.LineCount(Tests[4]));
            Assert.AreEqual(assert6, Program.LineCount(Tests[5]));
            Assert.AreEqual(assert7, Program.LineCount(Tests[6]));
            Assert.AreEqual(assert8, Program.LineCount(Tests[7]));
            return;
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
            return;
        }

        [TestMethod()]
        public void ListFilesTest()
        {
            string filePath = null;
            string[] expectedFiles = GetTestDir(out filePath);
            string[] actualFile = Program.ListFiles(filePath);
            //Array.Sort(a);
            if (expectedFiles.Length != actualFile.Length)
                Assert.Fail();
            for (int i = 0; i < expectedFiles.Length; i++)
                Assert.AreEqual(expectedFiles[i], actualFile[i]);
            return;
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
            return;
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
                charCount += line.Length;
                lines.Add(line);
            }
            File.WriteAllLines(tmpFile, lines);
            string a = File.ReadAllText(tmpFile);
            return tmpFile;
        }
        private static string[] GetTestDir(out string tmpDir)
        {
            tmpDir = Path.GetTempFileName();
            if (File.Exists(tmpDir))
                File.Delete(tmpDir);
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