using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace A10
{
    public class Matrix<_Type> : 
            IEnumerable<Vector<_Type>>,
            IEquatable<Matrix<_Type>>
        where _Type : IEquatable<_Type>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        protected readonly Vector<_Type>[] Rows;
        protected int RowAddIndex = 0;

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            Rows = new Vector<_Type>[rowCount];                
        }

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(IEnumerable<Vector<_Type>> rows)
        {
            if (rows.ToArray().Length == 0)
                throw new ArgumentException("Number of rows can't be zero.");
            Rows = new Vector<_Type>[rows.ToArray().Length];
            foreach(var item in rows)
            {
                this.Add(item);
            }
            RowCount = rows.ToArray().Length;
            ColumnCount = rows.ToArray()[0].Size;
        }

        public void Add(Vector<_Type> row)
        {
            this.Rows[RowAddIndex++] = row;
        }

        public Vector<_Type> this[int index]
        {
            get
            {
                if (index >= RowCount)
                    throw new IndexOutOfRangeException();
                return Rows[index];
            }
            set
            {
                if (index >= RowCount)
                    throw new IndexOutOfRangeException();
                if (value.Size != ColumnCount)
                    throw new ArithmeticException();
                this.Add(value);
            }
        }

        public _Type this[int row, int col]
        {
            get
            {
                if (RowCount <= row || ColumnCount <= col)
                    throw new IndexOutOfRangeException();
                return Rows[row][col];
            }
            set
            {
                if (RowCount <= row || ColumnCount <= col)
                    throw new IndexOutOfRangeException();
                Rows[row][col] = value;
            }
        }

        /// <summary>
        /// overloading + operator for the class Matrix customly
        /// </summary>
        /// <param name="m1">right hand side operand (type : matrix)</param>
        /// <param name="m2">left hand side operand (type : matrix)</param>
        /// <returns>a matrix as result of the sum</returns>
        public static Matrix<_Type> operator +(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if (m1.RowCount != m2.RowCount || m1.ColumnCount != m2.ColumnCount)
                throw new InvalidOperationException();
            Matrix<_Type> result = new Matrix<_Type>(m1.RowCount, m1.ColumnCount);
            for(int i = 0; i < m1.RowCount; i++)
            {
                result[i] = m1.Rows[i] + m2.Rows[i];
            }
            return result;
        }

        /// <summary>
        /// Equals operator implementing
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator ==(Matrix<_Type> m1, Matrix<_Type> m2)
            => m1.Equals(m2);
        /// <summary>
        /// Not Equals operator implementing
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator !=(Matrix<_Type> m1, Matrix<_Type> m2)
            => !m1.Equals(m2);
        /// <summary>
        /// overloading * operator for matrix class
        /// </summary>
        /// <param name="m1">RHS of the operator</param>
        /// <param name="m2">LHS of the operator</param>
        /// <returns></returns>
        public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if (m1.ColumnCount != m2.RowCount)
                throw new InvalidOperationException();
            Matrix<_Type> result = new Matrix<_Type>(m1.RowCount, m2.ColumnCount);
            for(int i = 0; i < m1.RowCount; i++)
            {
                result[i] = new Vector<_Type>(m2.ColumnCount);
                for(int j = 0; j < m2.ColumnCount; j++)
                {
                    result[i][j] = m1[i] * m2.GetColumn(j);
                }
            }
            return result;
        }

        /// <summary>
        /// Get an enumerator that enumerates over elements in a column
        /// </summary>
        /// <param name="col"></param>
        /// <returns>IEnumerable</returns>
        protected IEnumerable<_Type> GetColumnEnumerator(int col)
        {
            if (col >= ColumnCount)
                throw new IndexOutOfRangeException();
            Vector<_Type> column = new Vector<_Type>(RowCount);
            for(int i = 0; i < RowCount; i++)
            {
                column[i] = this[i][col];
            }
            return column;
        }

        protected Vector<_Type> GetColumn(int col) => 
            new Vector<_Type>(GetColumnEnumerator(col));


        public bool Equals(Matrix<_Type> other)
        {
            if (other.ColumnCount != this.ColumnCount || other.RowCount != this.RowCount)
                return false;
            for (int i = 0; i < Rows.Length; i++)
            {
                if (!this[i].Equals(other[i]))
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix<_Type>))
                return false;
            return this.Equals(obj as Matrix<_Type>);
        }

        public override int GetHashCode()
        {
            int code = 0;
            foreach(var row in this.Rows)
                code ^= row.GetHashCode();

            return code;
        }

        public IEnumerator<Vector<_Type>> GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }
        public override string ToString()
        {
            string output = "[\n";
            foreach(var item in Rows)
            {
                if (item != Rows.Last())
                    output += item.ToString() + ",\n";
                else
                    output += item.ToString();
            }
            output += "\n]";
            return output;
        }
    }
}