using System;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake {
    public class Lock : Command{

        public const ushort ID = 6481;

        public int HeroX { get; private set; }
        public int HeroY { get; private set; }
        public int TargetID { get; private set; }
        public int TargetX { get; private set; }
        public int TargetY { get; private set; }

        public Lock(int hero_x, int hero_y, int id, int target_x, int target_y) {
            HeroX = hero_x;
            HeroY = hero_y;
            TargetID = id;
            TargetX = target_x;
            TargetY = target_y;
            Write();
        }

        public void Write() {
            packetWriter.Write((short)26);
            packetWriter.Write(ID);
            packetWriter.Write((short)3852);
            packetWriter.Write((int)((uint)TargetX >> 8 | (uint)TargetX << 24));
            packetWriter.Write((int)((uint)TargetID << 2 | (uint)TargetID >> 30));
            packetWriter.Write((int)((uint)HeroY >> 3 | (uint)HeroY << 29));
            packetWriter.Write((int)((uint)HeroX >> 16 | (uint)HeroX << 16));
            packetWriter.Write((short)23424);
            packetWriter.Write((int)((uint)TargetY << 8 | (uint)TargetY >> 24));


            /*
             *          param1.writeShort(3852);
         param1.writeInt(this.§_-3k§ >>> 8 | this.§_-3k§ << 24); target x
         param1.writeInt(this.§_-fs§ << 2 | this.§_-fs§ >>> 30); id
         param1.writeInt(this.§_-O4T§ >>> 3 | this.§_-O4T§ << 29); hero y
         param1.writeInt(this.§_-Yq§ >>> 16 | this.§_-Yq§ << 16); hero x
         param1.writeShort(23424);
         param1.writeInt(this.§_-c4h§ << 8 | this.§_-c4h§ >>> 24); target y

    */

        }
    }
}
