using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class DestroyItem : Command
    {
        public const ushort ID = 22554;

        public bool CollectedByPlayer { get; private set; } // name_46
        public string Hash { get; private set; }

        public DestroyItem(EndianBinaryReader reader)
        {
            CollectedByPlayer = reader.ReadBoolean();
            reader.ReadInt32();
            Hash = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadUInt16()));
        }
    }
}
