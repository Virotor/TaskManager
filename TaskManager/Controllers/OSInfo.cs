using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    class OSInfo : InfoBase<OperatingSystemModel, float>
    {
        public override List<OperatingSystemModel> TakeInfoAboutDivice()
        {
            List<OperatingSystemModel> operatingSystems = new List<OperatingSystemModel>();
            using (var oss = TakeManagementObject("BuildNumber,BuildType,Caption,Name,OSArchitecture,TotalSwapSpaceSize,TotalVirtualMemorySize,CurrentTimeZone,Version,LastBootUpTime", "Win32_OperatingSystem").Get())
            {
                foreach(var _ in oss)
                {
                    operatingSystems.Add(new OperatingSystemModel()
                    {
                        BuildNumber = _["BuildNumber"].ToString(),
                        BuildType = _["BuildType"].ToString(),
                        Caption = _["Caption"].ToString(),
                        Name = _["Name"].ToString(),
                        OSArchitecture = _["OSArchitecture"].ToString(),
                        Version = _["Version"].ToString(),
                        TotalSwapSpaceSize = Convert.ToUInt64(_["TotalSwapSpaceSize"]),
                        TotalVirtualMemorySize = Convert.ToUInt64(_["TotalVirtualMemorySize"]),
                        CurrentTimeZone = Convert.ToInt16(_["CurrentTimeZone"]),
                        LastBootUpTime = new string( _["LastBootUpTime"].ToString().TakeWhile(x => x != '.').ToArray())
                    }) ;
                }
            }
            return operatingSystems;
        }

        protected override float InitilizatorC()
        {
            return 0;
        }

        protected override float TakeInfo()
        {
            throw new NotImplementedException();
        }
    }
}
