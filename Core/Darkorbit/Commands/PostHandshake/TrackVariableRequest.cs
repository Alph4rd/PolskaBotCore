using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake {
    public class TrackVariableRequest : Command{
        public const ushort ID = 21272;

        public string payload { get; private set; } = "map_clicks";

        public TrackVariableRequest() {
            Write();
        }

        public void Write() {
            packetWriter.Write((short)(payload.Length + 20));
            packetWriter.Write(ID);
            packetWriter.Write((int)1);
            packetWriter.Write((short)14745); // §_-34e§ ID
            packetWriter.Write(new byte[3]{175, 69, 0 });
            packetWriter.Write(payload);
            packetWriter.Write((short)116);
            packetWriter.Write((byte)0);
            packetWriter.Write((byte)1);
            packetWriter.Write((byte)0);
            packetWriter.Write((byte)0);
            packetWriter.Write((byte)164);
            packetWriter.Write((byte)150);

        }
    }
}
