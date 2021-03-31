using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Processor
    {
        public UInt16 AddressWidth { get; set; }

        public ProcesorArchitecture ProcesorArchitecture { get; set; }

        public UInt32 L2CacheSize { get; set; }
        public UInt32 L3CacheSize { get; set; }

        public UInt16 MaxClockSpeed { get; set; }

        public UInt16 CurrentClockSpeed { get; set; }

        public string Name { get; set; }

        public UInt32 NumberOfLogicalProcessors { get; set; }

        public UInt32 NumberOfEnabledCore { get; set; }

    }
}
