﻿using System;
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
        /// <summary>
        /// returns a new matrix with replacing column of this matrix.
        /// </summary>
        /// <param name="columnVector"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public SquareMatrix<_Type> ReplaceColumn(Vector<_Type> columnVector, int index)
        {
            SquareMatrix<_Type> matrix = new SquareMatrix<_Type>(this.Size);
            
            if (index > Size - 1 || index < 0)
                throw new ArgumentException();
            for (int i = 0; i < Size; i++)
            {
                matrix[i] = new Vector<_Type>(Size);
                for (int j = 0; j < Size; j++)
                    matrix[i][j] = this[i][j];
                matrix[i][index] = columnVector[i];
            }
            return matrix;
        }
        /// <summary>
        /// calculate determinant of matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
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
                determinant += (dynamic)(int)Math.Pow(-1, i % 2) * matrix[0][i] * Determinant(minorMatrix);
            }
            return determinant;
        }
    }
}