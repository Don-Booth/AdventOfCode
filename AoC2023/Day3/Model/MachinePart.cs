using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Model
{
    internal class MachinePart
    {
        public int PartNumber { get; set; }
        public bool IsAGenuinePart { get; set; }

        public MachinePart()
        {
            IsAGenuinePart = false;
        }
    }
}
