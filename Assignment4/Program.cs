using System;
using System.Collections.Generic;

namespace Assignment4
{
    internal class Program
    {// Ваш номер 13.
        static void Main(string[] args)
        {
            Vector arr = new Vector(25);
            arr.InitShuffle();
            Console.WriteLine(arr.ToString());
            // краще зовнішнй enum
            arr.QuickSort(Vector.PivotType.Last, 0, 15);
            Console.WriteLine(arr.ToString());

        }
    }
}
