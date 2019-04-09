using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    public class ShipMove : Command
    {
        public const ushort ID = 27198;

        public uint UserID { get; private set; } //name_125
        public int X { get; private set; }
        public int Y { get; private set; }
        public uint Duration { get; private set; } //var_3506

        public ShipMove(EndianBinaryReader reader)
        {
            UserID = reader.ReadUInt32();
            UserID = UserID >> 4 | UserID << 28;
            Y = reader.ReadInt32();
            Y = (int)((uint)Y >> 7 | (uint)Y << 25);
            Duration = reader.ReadUInt32();
            Duration = Duration >> 3 | Duration << 29;
            reader.ReadInt16();
            X = reader.ReadInt32();
            X = (int)((uint)X << 8 | (uint)X >> 24);
        }
    }
}
