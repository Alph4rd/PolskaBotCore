using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake {
    class MapRepairChange : Command {
        public const ushort ID = 18131;

        public int MapID { get; private set; }

        public MapRepairChange(EndianBinaryReader reader) {
            reader.ReadInt32();
            MapID = reader.ReadInt32();
            MapID = (int)((uint)MapID << 7 | (uint)MapID >> 25);
            reader.ReadUInt16();
        }
    }
}
