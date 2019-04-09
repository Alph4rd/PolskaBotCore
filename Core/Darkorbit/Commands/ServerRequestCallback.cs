using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands
{
    class ServerRequestCallback : Command
    {
        public const ushort ID = 24407;

        public int length { get; private set; }
        public byte[] secretKey { get; private set; }

        public ServerRequestCallback(EndianBinaryReader reader)
        {
            short n = reader.ReadInt16();
            length = reader.ReadInt32();
            secretKey = reader.ReadBytes(length);
        }
    }
}
