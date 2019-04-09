using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class ShipDestroyed : Command
    {
        public const ushort ID = 28665;

        public int UserID { get; private set; } //var_2750
        public int var_1092 { get; private set; } //var_1092

        public ShipDestroyed(EndianBinaryReader reader)
        {
            UserID = reader.ReadInt32();
            UserID = (int)((uint)UserID >> 4 | (uint)UserID << 28);
            var_1092 = reader.ReadInt32();
            var_1092 = (int)((uint)var_1092 >> 24 | (uint)var_1092 << 18);
        }
    }
}
