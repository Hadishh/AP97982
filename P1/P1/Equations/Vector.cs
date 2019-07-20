using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    /// <summary>
    /// A vector of numbers. Implement vector addition and multiplication.
    /// </summary>
    /// <typeparam name="_Type"></typeparam>
    public class Vector<_Type> : 
        IEnumerable<_Type>, IEquatable<Vector<_Type>>
        where _Type: IEquatable<_Type>        
    {
        /// <summary>
        /// Vector data
        /// </summary>
        protected readonly _Type[] Data;

        /// <summary>
        /// Add index. Only used for collection initialization.
        /// </summary>
        protected int AddIndex = 0;

        /// <summary>
        /// Vector Size
        /// </summary>
        public int Size => Data.Length;

        /// <summary>
        /// Add method to allow collection initialization.
        /// </summary>
        /// <param name="v"></param>
        public void Add(_Type v)
        {
            Data[AddIndex++] = v;
            return;
        }

        /// <summary>
        /// Create a new Vector
        /// </summary>
        /// <param name="length">Vector length</param>
        public Vector(int length)
        {
            this.Data = new _Type[length];
        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public Vector(Vector<_Type> other)
            : this(other.Size)
        {
            Data = other.Data;
            AddIndex = Data.Length - 1;
        }

        /// <summary>
        /// Constructor for IEnumerable
        /// </summary>
        /// <param name="list">IEnumerable of _Type</param>
        public Vector(IEnumerable<_Type> list)
            : this(list.Count())
        {
            Data = list.ToArray();
            AddIndex = Data.Length - 1;
        }

        /// <summary>
        /// Accessor for data elements
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public _Type this[int index]
        {
            get
            {
                if (index >= Size)
                    throw new IndexOutOfRangeException();
                return Data[index];
            }
            set
            {
                if (index >= Size)
                    throw new IndexOutOfRangeException();
                Data[index] = value;
            }
        }

        /// <summary>
        /// Add two vectors
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>sum of vector 1 and 2</returns>
        public static Vector<_Type> operator +(Vector<_Type> v1, Vector<_Type> v2)
        {
            if (v1.Size != v2.Size)
                throw new ArithmeticException("Vectors don't have same size!");
            Vector<_Type> result = new Vector<_Type>(v1.Size);
            for(int i = 0; i < result.Size; i++)
            {
                dynamic v1Item = v1[i];
                dynamic v2Item = v2[i];
                dynamic data = v1Item + v2Item;
                result[i] = data;
            }
            return result;
        }

        /// <summary>
        /// Subtract two vectors
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>sum of vector 1 and 2</returns>
        public static Vector<_Type> operator -(Vector<_Type> v1, Vector<_Type> v2)
        {
            if (v1.Size != v2.Size)
                throw new ArithmeticException("Vectors don't have same size!");
            Vector<_Type> result = new Vector<_Type>(v1.Size);
            for (int i = 0; i < result.Size; i++)
            {
                dynamic v1Item = v1[i];
                dynamic v2Item = v2[i];
                dynamic data = v1Item - v2Item;
                result[i] = data;
            }
            return result;
        }

        /// <summary>
        /// Inner product of two vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>Inner product of vector one and two</returns>
        public static _Type operator *(Vector<_Type> v1, Vector<_Type> v2)
        {
            if (v1.Size != v2.Size)
                throw new ArithmeticException("Vectors don't have same size!");
            Vector<_Type> result = new Vector<_Type>(v1.Size);
            dynamic data = 0;
            for (int i = 0; i < result.Size; i++)
                data += (dynamic)v1[i] * v2[i];
            return data;
        }

        /// <summary>
        /// Product of contanst to a vector
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>Inner product of vector one and two</returns>
        public static Vector<_Type> operator *(Vector<_Type> v2, _Type v1)
        {
            Vector<_Type> result = new Vector<_Type>(v2.Size);
            dynamic data = 0;
            for (int i = 0; i < result.Size; i++)
                result[i] += (dynamic)v1 * v2[i];
            return result;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>whether v1 is equal to v2</returns>
        public static bool operator ==(Vector<_Type> v1, Vector<_Type> v2) 
            => v1.Equals(v2);
      

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>v1 not equal to v2</returns>
        public static bool operator !=(Vector<_Type> v1, Vector<_Type> v2)
            => !v1.Equals(v2);
        /// <summary>
        /// Override Object.Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Whether this object is equal to obj</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector<_Type>))
                return false;
            if (!this.Equals(obj as Vector<_Type>))
                return false;
            return true;
        }

        /// <summary>
        /// Implementing IEquatable interface
        /// </summary>
        /// <param name="other">another vector</param>
        /// <returns>whether other vector is equal to this vector</returns>
        public bool Equals(Vector<_Type> other)
        {
            if (this.Size != other.Size)
                return false;
            for (int i = 0; i < Size; i++)
                if ((dynamic)Data[i] != other.Data[i])
                    return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var item in this)
                hash ^= item.GetHashCode();
            return hash;
        }

        public IEnumerator<_Type> GetEnumerator()
        {
            foreach (_Type item in Data)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.Data.GetEnumerator();
        
        public override string ToString()
        {
            string output = "[";
            output += string.Join(",", this);
            output += "]";
            return output;
        }
    }
}
