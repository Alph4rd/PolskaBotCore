using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    public class Jump : Command
    {
        public const short ID = 5986;

        public Jump()
        {
            Write();
        }

        public void Write()
        {
            packetWriter.Write((short)4);
            packetWriter.Write(ID);
            packetWriter.Write((short)29041);
        }
    }
}
