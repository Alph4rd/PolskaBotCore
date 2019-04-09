using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake
{
    class HeroInit : Command
    {
        public const ushort ID = 8273;

        public float Jackpot { get; private set; }
        public uint MaxShield { get; private set; } //name_103
        public bool Premium { get; private set; }
        public bool var_4823 { get; private set; }
        public double Credits { get; private set; }
        public double Honor { get; private set; } //var_4055
        public uint ClanID { get; private set; } //name_48
        public double Uridium { get; private set; }
        public bool var_3678 { get; private set; }
        public uint Rank { get; private set; } //name_134
        public bool Cloaked { get; private set; }
        public string Username { get; private set; } //var_3495
        public uint Speed { get; private set; }
        public int CargoCapacity { get; private set; } //var_3020
        public uint Shield { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public uint UserID { get; private set; } //name_125
        public uint var_3377 { get; private set; } //h4p§
        public uint var_3914 { get; private set; } //var_3914
        public uint FreeCargoSpace { get; private set; } //var_4296
        public string Shipname { get; private set; } //name_122
        public uint HP { get; private set; } //var_1065
        public uint Level { get; private set; }
        public uint NanoHP { get; private set; } //var_2224
        public double XP { get; private set; } //var_4549
        public uint Map { get; private set; }
        public uint FactionID { get; private set; }
        public string ClanTag { get; private set; } //name_138
        public uint MaxHP { get; private set; } //var_1851
        public uint MaxNanoHP { get; private set; } //var_1600

        public HeroInit(EndianBinaryReader reader)
        {
            HP = reader.ReadUInt32();
            HP = HP << 12 | HP >> 20;
            Credits = reader.ReadDouble();
            ClanTag = Encoding.Default.GetString(reader.ReadBytes(reader.ReadUInt16()));
            Cloaked = reader.ReadBoolean();
            FreeCargoSpace = reader.ReadUInt32();
            FreeCargoSpace = FreeCargoSpace >> 12 | FreeCargoSpace << 20;
            Jackpot = reader.ReadSingle();
            MaxShield = reader.ReadUInt32();
            MaxShield = MaxShield << 7 | MaxShield >> 25;
            FactionID = reader.ReadUInt32();
            FactionID = FactionID << 10 | FactionID >> 22;
            MaxHP = reader.ReadUInt32();
            MaxHP = MaxHP << 15 | MaxHP >> 17;
            var_3678 = reader.ReadBoolean();
            Shield = reader.ReadUInt32();
            Shield = Shield << 9 | Shield >> 23;
            var_4823 = reader.ReadBoolean();
            ClanID = reader.ReadUInt32();
            ClanID = ClanID << 2 | ClanID >> 30;
            reader.ReadInt16();
            Speed = reader.ReadUInt32();
            Speed = Speed >> 6 | Speed << 26;
            var_3914 = reader.ReadUInt32();
            var_3914 = var_3914 >> 2 | var_3914 << 30;
            Map = reader.ReadUInt32();
            Map = Map >> 10 | Map << 22;
            UserID = reader.ReadUInt32();
            UserID = UserID << 11 | UserID >> 21;
            Username = Encoding.Default.GetString(reader.ReadBytes(reader.ReadUInt16()));
            reader.ReadUInt32();
            Level = reader.ReadUInt32();
            Level = Level >> 13 | Level << 19;
            Y = reader.ReadInt32();
            Y = (int)((uint)Y << 3 | (uint)Y >> 29);
            Premium = reader.ReadBoolean();
            int length = reader.ReadInt32();
            if (length > 0) {
                for (int i = 0; i < length; i++) {

                    reader.ReadInt32();
                    Class326 class326 = new Class326(reader);
                }
            }
            NanoHP = reader.ReadUInt32();
            NanoHP = NanoHP << 3 | NanoHP >> 29;
            Honor = reader.ReadDouble();
            var_3377 = reader.ReadUInt32();
            var_3377 = var_3377 >> 2 | var_3377 << 30;
            reader.ReadUInt16(); // ....
            Shipname = Encoding.Default.GetString(reader.ReadBytes(reader.ReadUInt16()));
            Uridium = reader.ReadDouble();
            CargoCapacity = reader.ReadInt32();
            CargoCapacity = (int)((uint)CargoCapacity << 7 | (uint)CargoCapacity >> 25);
            XP = reader.ReadDouble();
            X = reader.ReadInt32();
            X = (int)((uint)X >> 1 | (uint)X << 31);
        }
    }
}