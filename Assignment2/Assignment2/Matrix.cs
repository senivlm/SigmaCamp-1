using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Matrix
    {
        #region Fields
        private int[,] _matrix;
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
            int counter = 1;
            int[] deltas = { (int)(-1 * Math.Pow(-1, (mode == Modes.StartRight ? 0 : 1))), (int)Math.Pow(-1, (mode == Modes.StartRight ? 0 : 1)) };
            int[] indexes = { 0, 0 };
            int[] boundaries = { _matrix.GetLength(0), _matrix.GetLength(1), -1, -1 };

            while (counter <= _matrix.Length)
            {
                _matrix[indexes[0], indexes[1]] = counter++;
                if (!CheckCollisions(indexes, boundaries, deltas, mode))
                {
                    for (int i = 0; i < 2; i++)
                    {
                        indexes[i] += deltas[i];
                    }
                }
            }
        }

        public enum Modes
        {
            StartRight = 0,
            StartDown = 1
        }

        private static bool CheckCollision(ref int comparedIndex, int boundary, ref int anotherIndex, ref int cDelta,
            ref int aDelta)
        {
            if (comparedIndex + cDelta != boundary) return false;
            anotherIndex++;
            cDelta *= -1;
            aDelta *= -1;
            return true;
        }

        private static bool CheckCollisions(int[] indexes, int[] boundaries, int[] deltas, Modes mode)
        {
            for (int ctr = 0; ctr < 4; ctr++)
            {
                int i = ctr + (mode == Modes.StartDown ? 1 : 0) * (int)Math.Pow(-1, ctr % 2);
                if (CheckCollision(ref indexes[i % 2], boundaries[i], ref indexes[(i + 1) % 2], ref deltas[i % 2],
                        ref deltas[(i + 1) % 2])) return true;
            }

            return false;
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
