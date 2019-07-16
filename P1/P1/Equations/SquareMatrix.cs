using System;
using System.Collections.Generic;
using System.IO;

namespace P1
{

    public class SquareMatrix<_Type> : Matrix<_Type>
         where _Type : IEquatable<_Type>
    {
        public SquareMatrix(int rows)
        : base(rows, rows)
        {
            
        }
        public int Size { get => this.RowCount; }
        public static _Type Determinant(SquareMatrix<_Type> matrix)
        {
            if (matrix.Size == 2)
                return (dynamic)matrix[0][0] * matrix[1][1] - (dynamic)matrix[0][1] * matrix[1][0];
            _Type determinant = (dynamic)0;
            for(int i = 0; i < matrix.Size; i++)
            {
                SquareMatrix<_Type> minorMatrix = new SquareMatrix<_Type>(matrix.Size - 1);
                Vector<_Type> vector;
                for(int j = 1; j < matrix[0].Size; j++)
                {
                    vector = new Vector<_Type>(matrix.Size - 1);
                    for (int k = 0; k < matrix.Size; k++)
                        if (k != i)
                            vector.Add(matrix[j][k]);
                    minorMatrix.Add(vector);
                }
                determinant += (dynamic)(int)Math.Pow(-1, i % 2) * Determinant(minorMatrix);
            }
            return determinant;
        }
    }
}