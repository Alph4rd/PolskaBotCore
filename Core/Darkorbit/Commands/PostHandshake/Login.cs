using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class Login : Command
    {
        public const ushort ID = 26524;

        public int UserID { get; private set; }
        public string SID { get; private set; }
        public short FactionID { get; private set; }
        public int InstanceID { get; private set; }
        public string Version { get; private set; }

        public Login(int userID, string sessionID, short factionID, int instanceID, string version = Config.VERSION)
        {
            UserID = userID;
            SID = sessionID;
            FactionID = factionID;
            InstanceID = instanceID;
            Version = version;
            Write();
        }

        public void Write()
        {
            var utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(SID);
            

            short totalLength = (short)(SID.Length + Version.Length + 20);
            packetWriter.Write(totalLength); 
            packetWriter.Write(ID);
            packetWriter.Write(FactionID); 
            packetWriter.Write((short)12770);
            packetWriter.Write((InstanceID >> 9 | InstanceID << 23));
            packetWriter.Write((byte)0);
            packetWriter.Write((byte)SID.Length);
            packetWriter.Write(utfBytes);
            packetWriter.Write((byte)0);
            packetWriter.Write(Version);
            packetWriter.Write((short)-9222); 
            packetWriter.Write(UserID >> 1 | UserID << 31);
        }
    }
}
