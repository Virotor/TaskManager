using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class NetworkInfo : InfoBase<NetworkAdapter, UInt64>
    {
        public override List<NetworkAdapter> TakeInfoAboutDivice()
        {
            List<NetworkAdapter> networkAdapters = new List<NetworkAdapter>();
            using(var networkAdaptersSearch = TakeManagementObject("AdapterType,MACAddress,Manufacturer,MaxSpeed,Name,NetworkAddresses,Speed", "Win32_NetworkAdapter where PhysicalAdapter = 1").Get())
            {
                foreach(var adapter in networkAdaptersSearch)
                {
                    networkAdapters.Add(new NetworkAdapter() {
                        AdapterType = adapter["AdapterType"].ToString(),
                        MACAddress = adapter["MACAddress"].ToString(),
                        Manufacturer = adapter["Manufacturer"].ToString(),
                        Name = adapter["Name"].ToString(),
                        NetworkAddresses =(string[])adapter["NetworkAddresses"],
                        MaxSpeed =Convert.ToUInt64( adapter["MaxSpeed"]),
                        Speed = Convert.ToUInt64(adapter["Speed"])
                    });
                }
            }
            return networkAdapters;
        }

        protected override ulong InitilizatorC()
        {
            return 0;
        }

        protected override ulong TakeInfo()
        {
            using (var manag = TakeManagementObject("MaxSpeed", "Win32_NetworkAdapter").Get())
            {
                foreach (var _ in manag)
                {
                    return Convert.ToUInt64(_["MaxSpeed"]);
                }
            }
            return 0;
        }
    }
}
