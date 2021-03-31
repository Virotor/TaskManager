using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager 
{
    class ProcessorInfo : InfoBase<Processor,float>
    {

        private PerformanceCounter perfomanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        public UInt16 CurrentClockSpeed { get {
                return TakeSpeed();
            } }

        public override List<Processor> TakeInfoAboutDivice()
        {
            List<Processor> resultOfQuery = new List<Processor>();
            using (var manag = TakeManagementObject("Architecture,AddressWidth,CurrentClockSpeed,L2CacheSize,L3CacheSize,MaxClockSpeed,Name,NumberOfCores,NumberOfLogicalProcessors", "Win32_Processor").Get())
            {
                foreach (var elem in manag)
                {
                    resultOfQuery.Add(new Processor()
                    {
                        NumberOfLogicalProcessors = (UInt32)Convert.ToInt32(elem["NumberOfLogicalProcessors"]),
                        Name = elem["Name"].ToString(),
                        NumberOfEnabledCore = (UInt32)Convert.ToInt32(elem["NumberOfCores"]),
                        MaxClockSpeed = (UInt16)Convert.ToInt32(elem["MaxClockSpeed"]),
                        L2CacheSize = (UInt32)Convert.ToInt32(elem["L2CacheSize"]),
                        L3CacheSize = (UInt32)Convert.ToInt32(elem["L3CacheSize"]),
                        AddressWidth = (UInt16)Convert.ToInt16(elem["AddressWidth"]),
                        CurrentClockSpeed = (UInt16)Convert.ToInt32(elem["CurrentClockSpeed"]),
                        ProcesorArchitecture = (ProcesorArchitecture)Enum.Parse(typeof(ProcesorArchitecture), elem["Architecture"].ToString())
                    });
                }
            }
            return resultOfQuery;
        }

        protected override float InitilizatorC()
        {
            return 0.0f;
        }

        protected override float TakeInfo()
        {
            return perfomanceCounter.NextValue();
        }

        private UInt16 TakeSpeed()
        {
            using (var manag = TakeManagementObject("CurrentClockSpeed", "Win32_Processor").Get())
            {
                foreach (var _ in manag)
                {
                    return (UInt16)Convert.ToInt32(_["CurrentClockSpeed"]);
                }
               
            }
            return 0;
        }
        
    }
}
