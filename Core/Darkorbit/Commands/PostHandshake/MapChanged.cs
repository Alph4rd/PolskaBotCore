using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class MapChanged : Command
    {
        public const ushort ID = 17588;

        public int MapID { get; private set; }
        public int GateID { get; private set; }

        public MapChanged(EndianBinaryReader reader)
        {
            reader.ReadUInt16();
            MapID = reader.ReadInt32();
            MapID = (int)((uint)MapID << 9 | (uint)MapID >> 23);
            GateID = reader.ReadInt32();
            GateID = (int)((uint)GateID >> 14 | (uint)GateID << 18);
        }
    }
}
