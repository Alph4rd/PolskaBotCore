using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    public class CollectBox : Command
    {
        public const ushort ID = 8992;

        public int BoxPosX { get; private set; } //var_3696
        public string Hash { get; private set; } //var_3886
        public int ShipPosX { get; private set; } //var_4802
        public int BoxPosY { get; private set; } //var_715
        public int ShipPosY { get; private set; } //var_2321

        public CollectBox(string Hash, int BoxPosX, int BoxPosY, int ShipPosX, int ShipPosY)
        {
            this.Hash = Hash;
            this.BoxPosX = BoxPosX;
            this.BoxPosY = BoxPosY;
            this.ShipPosX = ShipPosX;
            this.ShipPosY = ShipPosY;
            Write();
        }

        public void Write()
        {
            packetWriter.Write((short)(24 + Hash.Length));
            packetWriter.Write(ID);
            packetWriter.Write((short)Hash.Length);
            packetWriter.Write(Encoding.UTF8.GetBytes(Hash));
            packetWriter.Write((short)19153);
            packetWriter.Write((int)((uint)BoxPosY << 12 | (uint)BoxPosY >> 20));
            packetWriter.Write((int)((uint)BoxPosX << 14 | (uint)BoxPosX >> 18));
            packetWriter.Write((int)((uint)ShipPosX << 3 | (uint)ShipPosX >> 29));
            packetWriter.Write((short)-20208);
            packetWriter.Write((int)((uint)ShipPosY >> 10 | (uint)ShipPosY << 22));
            
            

        }
    }
}
