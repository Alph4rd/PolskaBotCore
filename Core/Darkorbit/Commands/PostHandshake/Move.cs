using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    public class Move : Command
    {
        public const ushort ID = 15728;

        public uint TargetX { get; private set; }   // name_135
        public uint TargetY { get; private set; }   // name_20
        public uint CurrentX { get; private set; }  // var_3310
        public uint CurrentY { get; private set; }  // var_14

        public Move(uint targetX, uint targetY, uint currentX, uint currentY)
        {
            TargetX = targetX;
            TargetY = targetY;
            CurrentX = currentX;
            CurrentY = currentY;
            Write();
        }

        public void Write()
        {
            packetWriter.Write((short)18);
            packetWriter.Write(ID); //2
            packetWriter.Write(TargetX << 3 | TargetX >> 29);
            packetWriter.Write(TargetY >> 13 | TargetY << 19);
            packetWriter.Write(CurrentY >> 12 | CurrentY << 20);
            packetWriter.Write(CurrentX << 10 | CurrentX >> 22);


            /*
           param1.writeInt(this.§_-3k§ << 3 | this.§_-3k§ >>> 29);
         param1.writeInt(this.§_-c4h§ >>> 13 | this.§_-c4h§ << 19);
         param1.writeInt(this.§_-A1p§ >>> 12 | this.§_-A1p§ << 20);
         param1.writeInt(this.§_-Q3s§ << 10 | this.§_-Q3s§ >>> 22);
             * */
        }
    }
}
