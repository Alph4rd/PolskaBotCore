using System;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake {
    public class Attack : Command {

        public const ushort ID = 9779;

        public int TargetID { get; private set; }
        public int TargetX { get; private set; }
        public int TargetY { get; private set; }

        public Attack(int id, int target_x, int target_y) {
            TargetID = id;
            TargetX = target_x;
            TargetY = target_y;
            Write();
        }

        public void Write() {
            packetWriter.Write((short)14);
            packetWriter.Write(ID);

            packetWriter.Write((int)((uint)TargetY << 7 | (uint)TargetY >> 25));
            packetWriter.Write((int)((uint)TargetID >> 16 | (uint)TargetID << 16));
            packetWriter.Write((int)((uint)TargetX >> 4 | (uint)TargetX << 28));
        }
    }
}
