using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class RAMInfo : InfoBase<RAM, (ulong,ulong)>
    {
        public override List<RAM> TakeInfoAboutDivice()
        {
            List<RAM> resultOfQuery = new List<RAM>();
            using ( var manag = TakeManagementObject("FormFactor,ConfiguredClockSpeed,Capacity,MemoryType", "Win32_PhysicalMemory").Get()){
                foreach (var elem in manag)
                {
                    resultOfQuery.Add(new RAM()
                    {
                        FormFactor = (FormFactorOfRAM)Enum.Parse(typeof(FormFactorOfRAM), elem["FormFactor"].ToString()),
                        SpeedOfRam = Convert.ToInt32(elem["ConfiguredClockSpeed"]),
                        SizeOfRAM = Convert.ToDouble(elem["Capacity"]) / (1024 * 1024 * 1024),
                        MemoryType = (MemoryType)Enum.Parse(typeof(MemoryType), elem["MemoryType"].ToString())
                    });
                }
             
            }
            return resultOfQuery;
        }

        protected override (ulong, ulong) InitilizatorC()
        {
            return (0, 0);
        }

        protected override (ulong,ulong) TakeInfo()
        {
            ulong totalMemory = 0;
            ulong busyMemory = 0;
            using (var manag = TakeManagementObject("TotalVisibleMemorySize,FreePhysicalMemory", "Win32_OperatingSystem").Get())
            {
                foreach (var elem in manag)
                {
                    totalMemory += Convert.ToUInt64(elem["TotalVisibleMemorySize"]);
                    busyMemory += Convert.ToUInt64(elem["TotalVisibleMemorySize"]) - Convert.ToUInt64(elem["FreePhysicalMemory"]);
                }

            }
            return (totalMemory, busyMemory);
        }


    }
}
