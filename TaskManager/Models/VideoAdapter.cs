using System;

namespace TaskManager
{
    internal class VideoAdapter
    {
        public string Name{ get;set;}
        public string AdapterCompatibility { get;set;}
        public uint AdapterRAM { get;set;}
        public  string InstalledDisplayDrivers { get;set;}
        public DateTime InstallDate { get;set;}
        public UInt32 MaxMemorySupported { get; set; }
        public string VideoProcessor { get; set; }
        public VideoMemoryType VideoMemoryType { get; set; }
    }
}