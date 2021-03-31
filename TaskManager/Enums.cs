using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    enum FormFactorOfRAM
    {
        Unknown,
        Other,
        SIP,
        DIP,
        ZIP,
        SOJ,
        Proprietary,
        SIMM,
        DIMM,
        TSOP,
        PGA,
        RIMM,
        SODIMM,
        SRIMM,
        SMD,
        SSMP,
        QFP,
        TQFP,
        SOIC,
        LCC,
        PLCC,
        BGA,
        FPBGA,
        LGA
    }

    enum MemoryType
    {
        Unknown,
        Other,
        DRAM,
        SynchronousDRAM,
        CacheDRAM,
        EDO,
        EDRAM,
        VRAM,
        SRAM,
        RAM,
        ROM,
        Flash,
        EEPROM,
        FEPROM,
        EPROM,
        CDRAM,
        D3RAM,
        SDRAM,
        SGRAM,
        RDRAM,
        DDR,
        DDR2,
        DDR2FBDIMM,
        DDR3=24,
        FBD2=25,
        DDR4=26,
    }


    enum ProcesorArchitecture
    {
        x86,
        MIPS,
        Alpha,
        PowerPC,
        ARM,
        ia64,
        x64 = 9
    }

    enum VideoMemoryType
    {
        Other= 1,
        Unknown,
        VRAM,
        DRAM,
        SRAM,
        WRAM,
        EDORAM,
        BurstSynchronousDRAM,
        PipelinedBurstSRAM,
        CDRAM,
        D3RAM,
        SDRAM,
        SGRAM,
    }


    enum ExecutionState {
        Unknown,
        Other,
        Ready,
        Running,
        Blocked,
        SuspendedBlocked,
        SuspendedReady,
        Terminated,
        Stopped,
        Growing
    }
}
