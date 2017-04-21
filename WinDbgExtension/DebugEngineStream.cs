using System;
using System.IO;
using System.Text;
using Microsoft.Diagnostics.Runtime.Interop;

namespace WinDbgExtension
{
    public class DebugEngineStream : Stream
    {
        private IDebugClient debugClient;
        private IDebugControl debugControl;

        public DebugEngineStream(IDebugClient debugClient)
        {
            this.debugClient = debugClient;
            this.debugControl = (IDebugControl) debugClient;
        }

        public override void Flush()
        {
            
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new System.NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new System.NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            string toBeWritten = Encoding.UTF8.GetString(buffer, offset, count);   
            debugControl.ControlledOutput(DEBUG_OUTCTL.AMBIENT_DML, DEBUG_OUTPUT.NORMAL, toBeWritten);
        }

        public override bool CanRead { get { return false; } }
        public override bool CanSeek { get { return false; } }
        public override bool CanWrite { get { return true; } }
        public override long Length { get { return -1; } }
        public override long Position { get; set; }
    }
}
