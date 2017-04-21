using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Diagnostics.Runtime.Interop;

namespace WinDbgExtension
{
    public class Command
    {
        private IDebugClient debugClient;

        public Command(IntPtr debugClientPointer)
        {
            Init(debugClientPointer);
        }

        private void Init(IntPtr debugClientPointer)
        {
            object unknownObject = Marshal.GetUniqueObjectForIUnknown(debugClientPointer);
            debugClient = (IDebugClient) unknownObject;
            StreamWriter stream = new StreamWriter(new DebugEngineStream(debugClient));
            stream.AutoFlush = true;
            Console.SetOut(stream);
        }

        public void DoStuff(string args)
        {
            MessageBox.Show("check your clipboard");
            Clipboard.SetText(args);
        }
    }
}
