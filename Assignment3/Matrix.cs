﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Matrix
    {
        #region Fields
        private int[,] _matrix;

        public enum Modes
        {
            StartDown,
            StartRight
        }
        #endregion

        #region Constructors
        public Matrix(int[,] source)
        {
            _matrix = source;
        }

        public Matrix(int height, int width)
        {
            _matrix = new int[height, width];
        }
        #endregion

        #region Methods
        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < _matrix.GetLength(0)) return _matrix[i, j];
                throw new Exception("Index out of range!");
            }
            set
            {
                if (i >= 0 && i < _matrix.GetLength(0)) _matrix[i, j] = value;
                throw new Exception("Index out of range!");
            }
        }

        public void DiagonalSnakeFill(Modes mode)
        {
            int contentArrIndex = 0;
            // Кількість ліній має бути на 1 меншою
            for (int i = 0; i < 2 * _matrix.GetLength(0); i++)
            {
                int j;
                bool increment;
                if (i % 2 == Convert.ToInt32(mode))
                {
                    j = 0;
                    increment = true;
                }
                else
                {
                    j = i;
                    increment = false;
                }
                while (j >= 0 && j <= i)
                {
                    if (j < _matrix.GetLength(0) && (i - j) < _matrix.GetLength(1))
                    {
                        _matrix[j, i - j] = contentArrIndex++;
                    }
                    if (increment)
                        j++;
                    else
                        j--;
                }
            }

        }

        public override string ToString()
        {
            string matrixAsString = "";
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1) - 1; j++)
                {
                    matrixAsString += $"{_matrix[i, j],3:D0},";
                }
                matrixAsString += $"{_matrix[i, _matrix.GetLength(1) - 1],3:D0}\n";
            }
            return matrixAsString + "\n";
        }
        #endregion
    }
}
