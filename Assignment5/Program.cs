using System;
using System.Collections.Generic;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = 25;
            Vector arr = new Vector(length);
            arr.InitShuffle();
            string sourceFile = "sourceFile";
            using (StreamWriter sw = new StreamWriter(sourceFile))
            {
                for (int i = 0; i < length; i++)
                {
                    sw.Write(arr[i]);
                    sw.Write(' ');
                }
            }

            

        }
    }
}