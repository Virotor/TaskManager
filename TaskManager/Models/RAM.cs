using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class RAM
    {
        public double SizeOfRAM { get; set; }

        public int SpeedOfRam { get; set; }

        public FormFactorOfRAM FormFactor {get;set;}

        public MemoryType MemoryType { get; set; }
    }
}
