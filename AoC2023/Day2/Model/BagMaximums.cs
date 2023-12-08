using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Model
{
    internal class BagMaximums
    {
        public int MaxRed {  get; set; }
        public int MaxGreen { get; set; }
        public int MaxBlue { get; set; }

        public BagMaximums() 
        { 
            MaxRed = 0;
            MaxGreen = 0;
            MaxBlue = 0;
        }

        public BagMaximums(int maxRed, int maxGreen, int maxBlue)
        {
            MaxRed = maxRed;
            MaxGreen = maxGreen;
            MaxBlue = maxBlue;
        }
    }
}
