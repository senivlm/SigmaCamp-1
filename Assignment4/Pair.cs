using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Pair
    {
        #region Fields
        private int number;
        private int freq;
        #endregion

        #region Constructors
        public Pair(int number, int freq)
        {
            this.Number = number;
            this.Freq = freq;
        }
        #endregion

        #region Methods
        public int Number { get => number; set => number = value; }
        public int Freq { get => freq; set => freq = value; }

        public override string ToString()
        {
            return $"{number} - {freq}";
        }
        #endregion
    }
}
