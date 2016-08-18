using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

// Quick memory scan for an array of bytes.

// [ USAGE ] ------------------------------------------------------------------------------
//
// AobScan takes in a string "process name" and the byte array pattern to search for.
//
// Example:
//      
//      string mask = "xxxxxxxx"; // Match the number of bytes in array
//      byte[] pattern = new byte[]{ 0xFF, 0xFF, 0xFF, 0xFF, 0x51, 0x55, 0xFC, 0x11 };
//
//      string dyn_mask = "xxxx???x"; // x for known, ? for unknown/dynamic
//      byte[] dyn_pattern = new byte[] { 0x31, 0x55, 0x78, 0x33, 0, 0, 0, 0x37 };
//
//      AobScanner = new AobMemScan();
//      IntPtr Address = AobScanner.AobScan("process name", pattern, mask);
//
//      if (Address != IntPtr.Zero)
//      {
//          int AddressNum = pAddr.ToInt32();
//          string AddressHex = string.Format("0x{0:X}", AddressNum);
//      }
//
// ----------------------------------------------------------------------------------------

namespace RocketStat
{
    class AobMemScan
    {
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        protected static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int dwLength);

        [StructLayout(LayoutKind.Sequential)]
        protected struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public uint AllocationProtect;
            public uint RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }
        List<MEMORY_BASIC_INFORMATION> MemReg { get; set; }

        public IntPtr AobScan(string ProcessName, byte[] Pattern, string mask)
        {
            Process[] P = Process.GetProcessesByName(ProcessName);

            if (P.Length == 0) return IntPtr.Zero;

            MemReg = new List<MEMORY_BASIC_INFORMATION>();
            MemInfo(P[0].Handle);

            for (int i = 0; i < MemReg.Count; i++)
            {
                byte[] buff = new byte[MemReg[i].RegionSize];
                ReadProcessMemory(P[0].Handle, MemReg[i].BaseAddress, buff, MemReg[i].RegionSize, 0);

                char[] char_mask = mask.ToCharArray();

                IntPtr Result = _Scan(buff, Pattern, char_mask);
                if (Result != IntPtr.Zero)
                    return new IntPtr(MemReg[i].BaseAddress.ToInt32() + Result.ToInt32());
            }

            return IntPtr.Zero;
        }

        public void MemInfo(IntPtr pHandle)
        {
            IntPtr Addy = new IntPtr();

            while (true)
            {
                MEMORY_BASIC_INFORMATION MemInfo = new MEMORY_BASIC_INFORMATION();

                int MemDump = VirtualQueryEx(pHandle, Addy, out MemInfo, Marshal.SizeOf(MemInfo));

                if (MemDump == 0) break;

                if ((MemInfo.State & 0x1000) != 0 && (MemInfo.Protect & 0x100) == 0)
                    MemReg.Add(MemInfo);

                Addy = new IntPtr(MemInfo.BaseAddress.ToInt32() + (int)MemInfo.RegionSize);
            }
        }

        //sIn = search in, sFor = searh for
        public IntPtr _Scan(byte[] sIn, byte[] sFor, char[] mask)
        {
            int[] sBytes = new int[256];          
            int End = sFor.Length - 1;
            int Pool = 0;

            for (int i = 0; i < 256; i++)
                sBytes[i] = sFor.Length;

            for (int i = 0; i < End; i++)
                sBytes[sFor[i]] = End - i;

            while (Pool <= sIn.Length - sFor.Length)
            {
                for (int i = End; (sIn[Pool + i] == sFor[i]) || (mask[i] == '?'); i--)
                    if (i == 0) return new IntPtr(Pool);

                Pool += sBytes[sIn[Pool + End]];
            }
            return IntPtr.Zero;
        }
    }
}