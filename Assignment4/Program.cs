using System;
using System.Collections.Generic;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector arr = new Vector(25);
            arr.InitShuffle();
            Console.WriteLine(arr.ToString());
            arr.QuickSort(Vector.PivotType.Last, 0, 15);
            Console.WriteLine(arr.ToString());

        }
    }
}