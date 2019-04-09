using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class ShieldUpdated : Command
    {
        public const ushort ID = 5659;

        public int MaxShield { get; private set; }  //name_101
        public int Shield { get; private set; }     //var_752

        public ShieldUpdated(EndianBinaryReader reader)
        {
            MaxShield = reader.ReadInt32();
            MaxShield = (int)((uint)MaxShield << 10 | (uint)MaxShield >> 22);
            reader.ReadInt16();
            Shield = reader.ReadInt32();
            Shield = (int)((uint)Shield << 13 | (uint)Shield >> 19);
            reader.ReadInt16();
        }
    }
}
