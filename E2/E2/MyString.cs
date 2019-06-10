using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2
{
    public class MyString
    {
        string Data;
        public MyString() { }
        public MyString(string data)
        {
            Data = data;
        }
        public static explicit operator MyString(string v)
        {
            return new MyString(v);
        }
        public override bool Equals(object obj)
        {
            if (obj is MyString)
            {
                return (obj as MyString).Data == this.Data;
            }
            else if (obj is string)
                return (this.Data == obj as string);
            else
                return false;
        }
        public static bool operator ==(MyString s1, object s2) => s1.Equals(s2);
        public static bool operator !=(MyString s1, object s2) => !s1.Equals(s2);
        public static bool operator ==(object s1, MyString s2) => s2.Equals(s1);
        public static bool operator !=(object s1, MyString s2) => !s2.Equals(s1);
        public static bool operator ==(MyString s1, MyString s2) => s2.Equals(s1);
        public static bool operator !=(MyString s1, MyString s2) => !s2.Equals(s1);
        public override string ToString() => Data;
        public static MyString operator ++(MyString v1)
        {
            v1.Data = v1.Data.ToUpper();
            return new MyString(v1.Data.ToUpper());
        }

        public static MyString operator --(MyString v1)
        {
            v1.Data = v1.Data.ToLower();
            return new MyString(v1.Data.ToLower());
        }
        public static explicit operator string(MyString v) => v.ToString();
    }

}
