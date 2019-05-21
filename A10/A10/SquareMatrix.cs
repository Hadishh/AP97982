using System;
using System.Collections.Generic;
using System.IO;

namespace A10
{

    public class SquareMatrix<_Type> : Matrix<_Type>
         where _Type : IEquatable<_Type>
    {
        public SquareMatrix(int rows)
        : base(rows, rows)
        {
        }
    }
}