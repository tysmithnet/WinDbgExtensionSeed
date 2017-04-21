using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Diagnostics.Runtime;
using Microsoft.Diagnostics.Runtime.Interop;

namespace WinDbgExtension
{
    public class MyCommand
    {
        private IDebugClient debugClient;

        public MyCommand(IntPtr debugClientPointer)
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
            DataTarget dt = DataTarget.CreateFromDebuggerInterface(debugClient);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Version: {dt.ClrVersions[0].Version}");
            Console.WriteLine(sb);
        }

        public void DoStuff(string args)
        {
            MessageBox.Show("check your clipboard");
            if (string.IsNullOrWhiteSpace(args))
                args = "try passing arguments next time";
            Clipboard.SetText(args);
            Console.WriteLine($"<b>{args}</b>");
        }
    }
}
