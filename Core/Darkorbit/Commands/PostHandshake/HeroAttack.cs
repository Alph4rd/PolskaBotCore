using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiscUtil.IO;

namespace PolskaBot.Core.Darkorbit.Commands.PostHandshake {
    public class HeroAttack : Command {
        public const ushort ID = 14135;

        public int UserID { get; private set; }
        public int AttackerID { get; private set; }
        public int AttackedID { get; private set; }
        public int damage { get; private set; }
        public int AttackHP { get; private set; }
        public int AttackShield { get; private set; }


        public HeroAttack(EndianBinaryReader reader) {
            AttackerID = reader.ReadInt32();
            AttackerID = (int)((uint)AttackerID << 3 | (uint)AttackerID >> 29);

            damage = reader.ReadInt32();
            damage = (int)((uint)damage >> 12 | (uint)damage << 20);

            reader.ReadInt32();
            reader.ReadBoolean();

            AttackHP = reader.ReadInt32();
            AttackHP = (int)((uint)AttackHP >> 11 | (uint)AttackHP << 21);

            AttackShield = reader.ReadInt32();
            AttackShield = (int)((uint)AttackShield << 8 | (uint)AttackShield >> 24);

            AttackedID = reader.ReadInt32();
            AttackedID = (int)((uint)AttackedID << 1 | (uint)AttackedID >> 31);

            reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
        }
    }
}
