using System;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;
using WinDbgExtension;

namespace WinDbgExtensions
{
    public static class Exports
    {
        [DllExport("DebugExtensionInitialize")]
        public static int DebugExtensionInitialize(ref uint version, ref uint flags)
        {
            version = GetExtensionVersion(0, 1);
            flags = 0;
            return 0;
        }
        
        [DllExport("mycommand")]
        public static UInt32 MyCommand(IntPtr debugClientPointer, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            MyCommand myCommand = new MyCommand(debugClientPointer);
            myCommand.DoStuff(args);
            return 0;
        }

        private static uint GetExtensionVersion(uint major, uint minor)
        {
            return ((major & 0xffff) << 16) | (minor & 0xffff);
        }
    }
}