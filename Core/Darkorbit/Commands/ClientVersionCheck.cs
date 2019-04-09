using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolskaBot.Core.Darkorbit.Commands
{
    class ClientVersionCheck : Command
    {
        public static ushort ID = 666;
        public short length { get; private set; } = 14;

        public int major { get; set; }
        public int minor { get; set; }
        public int build { get; set; }

        public ClientVersionCheck(int major = 0, int minor = 110, int build = 4)
        {
            this.major = major;
            this.minor = minor;
            this.build = build;
            Write();
        }

        public void Write()
        {
            packetWriter.Write(length);
            packetWriter.Write(ID);
            packetWriter.Write(major);
            packetWriter.Write(minor);
            packetWriter.Write(build);
        }
    }
}
