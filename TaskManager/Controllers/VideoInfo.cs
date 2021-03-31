using System;
using System.Collections.Generic;

namespace TaskManager
{
    class VideoInfo : InfoBase<VideoAdapter, float>
    {
        public override List<VideoAdapter> TakeInfoAboutDivice()
        {
            List<VideoAdapter> resultOfQuery = new List<VideoAdapter>();
            using (var _ = TakeManagementObject("Name, AdapterCompatibility,AdapterRAM,InstalledDisplayDrivers,InstallDate,MaxMemorySupported,VideoProcessor,VideoMemoryType", "Win32_VideoController").Get())
            {
                foreach(var videoAdapter in _)
                {
                    resultOfQuery.Add(new VideoAdapter()
                    {
                        Name = videoAdapter["Name"].ToString(),
                        AdapterCompatibility = videoAdapter["AdapterCompatibility"].ToString(),
                        AdapterRAM = (UInt32)Convert.ToInt32(videoAdapter["AdapterRAM"]),
                        InstalledDisplayDrivers = videoAdapter["InstalledDisplayDrivers"].ToString(),
                        //InstallDate =(DateTime)Convert.ToDateTime(videoAdapter["InstallDate"].ToString()),
                        MaxMemorySupported =(UInt32)Convert.ToInt32(videoAdapter["MaxMemorySupported"]),
                        VideoProcessor = videoAdapter["VideoProcessor"].ToString(),
                        VideoMemoryType =(VideoMemoryType)Enum.Parse(typeof(VideoMemoryType), videoAdapter["VideoMemoryType"].ToString())
                    });
                }
            }
            return resultOfQuery;
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
