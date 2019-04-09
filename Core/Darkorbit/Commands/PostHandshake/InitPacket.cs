using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class InitPacket : Command
    {
        public const ushort ID = 32235;

        public short Index { get; private set; }

        public string Message { get; private set; } = "2D 1366x659 .root1.instance522.MainClientApplication0.ApplicationSkin2.Group3.Group4._-S49_5.instance25095 root1 false -1";

        public InitPacket(short num)
        {
            this.Index = num;
            Write();
        }

        public void Write()
        {
            short totalLength = (short)(Message.Length + 8);
            packetWriter.Write(totalLength);
            packetWriter.Write(ID);
            packetWriter.Write((byte)0);
            packetWriter.Write(Message);
            packetWriter.Write((short)19611);
            packetWriter.Write(Index);
        }
    }
}
