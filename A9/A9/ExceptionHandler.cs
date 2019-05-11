using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }

        public readonly bool DoNotThrow;

        private string _Input;

        public static void ThrowIfOdd(int number)
        {
            if (number % 2 == 1)
                throw new InvalidDataException();
        }

        public string Input
        {
            get
            {
                try
                {
                    int size = _Input.Length;
                    return _Input;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }
            set
            {
                try
                {
                    if(value is null)
                    {
                        ExceptionHandler nullValue = null;
                        nullValue.ErrorMsg = "Omg";
                    }
                    _Input = value;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }

        public string FinallyBlockStringOut { get; set; }

        public void FinallyBlockMethod(string keyword)
        {
            int size;
            try
            {
                FinallyBlockStringOut = "InTryBlock:";
                size = keyword.Length;
                if (keyword == "ugly")
                    return;
                else if (keyword == "beautiful")
                    FinallyBlockStringOut += $"{keyword}:{size}:DoneWriting";
            }
            catch(NullReferenceException e)
            {
                FinallyBlockStringOut += $":{e.Message}";
                if (!DoNotThrow)
                    throw;
            }
            finally
            {
                FinallyBlockStringOut += ":InFinallyBlock";
            }
            FinallyBlockStringOut += ":EndOfMethod";

        }

        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    ExceptionHandler nullValue = null;
                    nullValue.ErrorMsg = "Omg";
                    ErrorMsg = "Hellow Testing";
                }
            }
            catch(NullReferenceException)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public void OverflowExceptionMethod()
        {
            try
            {
                if(Input != "10")
                    checked
                    {
                        int variable = int.MaxValue;
                        variable += 20;
                    }
            }
            catch (OverflowException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
            }
            catch (FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void NestedMethods()
        {
            MethodA();
        }

        private void MethodA()
        {
            MethodB();
        }

        private void MethodB()
        {
            MethodC();
        }

        private void MethodC()
        {
            MethodD();
        }

        private void MethodD()
        {
            throw new NotImplementedException();
        }

        public void FileNotFoundExceptionMethod()
        {
            try
            {
                if(Input != "10")
                    File.ReadAllLines(@"MyFile.txt");
            }
            catch(FileNotFoundException fne)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception " + fne.GetType();
            }
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                if (Input != "0") {
                    int[] array = new int[1];
                    array[123654] = 1;
                }
            }
            catch(IndexOutOfRangeException ie)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception " + ie.GetType();
            }
        }

        public void OutOfMemoryExceptionMethod()
        {
            try
            {
                int[] array;
                if (Input != "10")
                    array = new int [int.MaxValue];
            }
            catch(OutOfMemoryException oe)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception " + oe.GetType();
            }
        }

        public void MultiExceptionMethod()
        {
            try
            {
                if(Input == int.MaxValue.ToString())
                {
                    int[] array = new int[int.MaxValue];
                }
                if(Input == "1")
                {
                    int[] array = new int[2];
                    array[5649] = 0;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception " + e.GetType();
            }
            catch (OutOfMemoryException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception " + e.GetType();
            }
        }
    }
}
