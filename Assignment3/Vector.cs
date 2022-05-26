using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Vector
    {
        #region Fields
        int[] arr;

        #endregion

        #region Constructors
        public Vector(int[] arr)
        {
            this.arr = arr;
        }

        public Vector(int n)
        {
            arr = new int[n];
        }

        public Vector() { }
        #endregion

        #region Methods
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set
            {
                arr[index] = value;
            }
        }

        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(a, b);
            }
        }

        public void InitShuffle()
        {
            
            int[] temp = new int[arr.Length];
            int randIndex;
            Random myRandomizer = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = i + 1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                do
                {
                    randIndex = myRandomizer.Next(0, arr.Length);
                }
                while (temp[randIndex] == 0);
                arr[i] = temp[randIndex];
                temp[randIndex] = 0;
            }

            //Random random = new Random();
            //int x;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    while (arr[i] == 0)
            //    {
            //        x = random.Next(1, arr.Length + 1);
            //        bool isExist = false;
            //        for (int j = 0; j < i; j++)
            //        {
            //            if (x == arr[j])
            //            {
            //                isExist = true;
            //                break;
            //            }
            //        }
            //        if (!isExist)
            //        {
            //            arr[i] = x;
            //            break;
            //        }
            //    }
            //}
        }

        public Pair[] CalculateFreq()
        {

            Pair[] pairs = new Pair[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair(0, 0);

            }
            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (arr[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = arr[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }

        public bool IsPalindrom()
        {
            bool res = true;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - 1 - i])
                    res = false;
            }
            return res;
        }
        public void Reverse()
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
                //arr.Reverse();
            }
        }

        //returns start index of sequence and it`s length
        public (int start, int length) FindLongestUniqueSequence()
        {
            int maxSeqStartInd = 0;
            int maxSeqLength = 1;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int j = 1;
                int curSeqLength = 1;
                while (arr[i] == arr[i + j])
                {
                    curSeqLength++;
                    j++;
                }
                if (curSeqLength > maxSeqLength)
                {
                    maxSeqStartInd = i;
                    maxSeqLength = curSeqLength;
                    i = i + j - 1;
                }
            }
            return (maxSeqStartInd, maxSeqLength);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }
        #endregion
    }
}
