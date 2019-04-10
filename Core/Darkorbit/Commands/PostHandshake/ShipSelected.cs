using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake {
    public class ShipSelected : Command{

        public const ushort ID = 7112;

        public int UserID { get; private set; }
        public int MaxHP { get; private set; }
        public int HP { get; private set; }
        public int Shield { get; private set; }
        public int MaxShield { get; private set; }


        public ShipSelected(EndianBinaryReader reader) {
            reader.ReadBoolean();
            reader.ReadInt32();

            MaxShield = reader.ReadInt32();
            MaxShield = (int)((uint)MaxShield >> 9 | (uint)MaxShield << 23);

            reader.ReadInt16();
            reader.ReadInt16();
            reader.ReadInt32();

            UserID = reader.ReadInt32();
            UserID = (int)((uint)UserID >> 11 | (uint)UserID << 21);

            HP = reader.ReadInt32();
            HP = (int)((uint)HP << 14 | (uint)HP >> 18);

            reader.ReadInt32();

            MaxHP = reader.ReadInt32();
            MaxHP = (int)((uint)MaxHP << 13 | (uint)MaxHP >> 19);

            Shield = reader.ReadInt32();
            Shield = (int)((uint)Shield << 6 | (uint)Shield >> 26);
        }

    }
}
