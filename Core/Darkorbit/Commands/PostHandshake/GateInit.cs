using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class GateInit : Command
    {
        public const ushort ID = 6800;

        public int FactionID { get; private set; }
        public List<int> var_2358 { get; private set; } = new List<int>();
        public int X { get; private set; }
        public int GateType { get; private set; } //name_158
        public bool var_139 { get; private set; }
        public bool var_4990 { get; private set; }
        public int Y { get; private set; }
        public int AssetID { get; private set; } //var_5014 (?)

        public GateInit(EndianBinaryReader reader)
        {
            GateType = reader.ReadInt32();
            GateType = (int)((uint)GateType << 2 | (uint)GateType >> 30);
            AssetID = reader.ReadInt32();
            AssetID = (int)((uint)AssetID >> 14 | (uint)AssetID << 18);
            var_4990 = reader.ReadBoolean();
            X = reader.ReadInt32();
            X = (int)((uint)X >> 16 | (uint)X << 16);
            int length = reader.ReadInt32();
            if (length > 0) {
                for (int i = 0; i < length; i++) {
                    int value = reader.ReadInt32();
                    value = (int)((uint)reader.ReadInt32() >> 2 | (uint)value << 30);
                    var_2358.Add(value);
                }
            }
            reader.ReadUInt16();
            Y = reader.ReadInt32();
            Y = (int)((uint)Y << 2 | (uint)Y >> 30);
            FactionID = reader.ReadInt32();
            FactionID = (int)((uint)FactionID << 2 | (uint)FactionID >> 30);
            var_139 = reader.ReadBoolean();
            //reader.ReadUInt16();
           
        }
    }
}
