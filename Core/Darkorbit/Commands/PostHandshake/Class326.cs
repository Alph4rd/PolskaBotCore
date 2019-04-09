using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class Class326 : Command
    {
        public const ushort ID = 18881;

        public bool Activated { get; private set; }
        public ushort modifier { get; private set; }
        public byte[] var_2555 { get; private set; }
        public int Attribute { get; private set; }
        public int userId { get; private set; }
        public int Count { get; private set; }

        public Class326(EndianBinaryReader reader)
        {
            Count = reader.ReadInt32();
            Count = Count << 4 | Count >> 28;
            short strlen = reader.ReadInt16();
            var_2555 = reader.ReadBytes(strlen);
            
            Attribute = reader.ReadInt32();
            Attribute = Attribute >> 13 | Attribute << 19;
            userId = reader.ReadInt32();
            userId = userId >> 7 | userId << 25;
            modifier = reader.ReadUInt16();
            Activated = reader.ReadBoolean();


        }
    }
}