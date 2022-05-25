using System;
using System.Collections.Generic;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector arr = new Vector(5);
            arr.InitShuffle();
            Console.WriteLine(arr.ToString());
            Matrix matr = new Matrix(5, 5);
            matr.DiagonalSnakeFill(Matrix.Modes.StartDown);
            Console.WriteLine(matr.ToString()); 

            try
            {
                arr[0] = 999;
                Console.WriteLine(arr[21]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}