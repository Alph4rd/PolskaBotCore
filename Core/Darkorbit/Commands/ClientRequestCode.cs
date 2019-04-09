using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolskaBot.Core.Darkorbit.Commands
{
    class ClientRequestCode : Command
    {
        public const ushort ID = 10029;
        public short length { get; private set; } = 4;

        public ClientRequestCode()
        {
            Write();
        }

        public void Write()
        {
            packetWriter.Write(length);
            packetWriter.Write(ID);
            packetWriter.Write((short)10850);
        }
    }
}
