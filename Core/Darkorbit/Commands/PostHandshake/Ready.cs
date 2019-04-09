using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class Ready : Command
    {
        public const ushort ID = 18609;
        //AAJIsQ==

        public Ready()
        {
            Write();
        }

        public void Write()
        {
            packetWriter.Write((short)2);
            packetWriter.Write(ID);
        }
    }
}
