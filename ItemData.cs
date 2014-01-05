using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace MOTHER3
{
    class ItemData : M3Rom
    {
        public static int Address = 0xE5108;
        public static int Length = 108;
        public static int Entries = 256;
        public static ItemData[] Items = new ItemData[Entries];

        private int index;
        public byte ItemType;
        public bool KeyItem;
        public ushort Sell;
        public byte EquipOwner;
        public int Hp;
        public short Pp;
        public sbyte Off;
        public sbyte Def;
        public sbyte Iq;
        public sbyte Speed;
        public short[] ProtectionAilment = new short[11];
        public sbyte[] ProtectionPsi = new sbyte[5];
        public ushort Hp1;
        public ushort Hp2;

        // +0x4 [1]: Item type
        // +0x8 [1]: (Not) key item
        // +0xA [2]: Sell price
        // +0xC [1]: Who can equip
        //        0x01: ?
        //        0x02: Flint
        //        0x04: Lucas
        //        0x08: Duster
        //        0x10: Kumatora
        //        0x20: Boney
        //        0x40: Salsa
        //        0x80: ?
        // +0x10: HP
        // +0x14: PP
        // +0x18: Offense
        // +0x19: Defense
        // +0x1A: IQ
        // +0x1B: Speed
        // +0x20 to +0x35 [2*11]: Status ailment protection?
        //        #0: Poison
        //        #1: Paralysis
        //        #2: Sleep
        //        #3: Strange
        //        #4: Cry
        //        #5: Forgetful
        //        #6: Nausea
        //        #7: Fleas
        //        #8: Burned
        //        #9: Solidified
        //        #10: Numbness? (Manly Bandana)
        // +0x36 [1]: PK Love? 
        // +0x37 [1]: PK Fire?
        // +0x38 [1]: PK Freeze?
        // +0x39 [1]: PK Thunder?
        // +0x3A [1]: Bomb?
        // +0x4E: Lower HP
        // +0x50: Upper HP

        // TODO: Verify with no$gba how wide these fields are

        public static void Init()
        {
            Rom.Seek(Address);
            for (int i = 0; i < Entries; i++)
            {
                var id = new ItemData();
                id.index = i;

                Rom.SeekAdd(4);

                id.ItemType = Rom.ReadByte();

                Rom.SeekAdd(3);

                id.KeyItem = Rom.ReadByte() == 0;

                Rom.SeekAdd(1);

                id.Sell = Rom.ReadUShort();
                id.EquipOwner = Rom.ReadByte();

                Rom.SeekAdd(3);

                id.Hp = Rom.ReadInt();
                id.Pp = Rom.ReadShort();

                Rom.SeekAdd(2);

                id.Off = Rom.ReadSByte();
                id.Def = Rom.ReadSByte();
                id.Iq = Rom.ReadSByte();
                id.Speed = Rom.ReadSByte();

                Rom.SeekAdd(4);

                for (int j = 0; j < id.ProtectionAilment.Length; j++)
                    id.ProtectionAilment[j] = Rom.ReadShort();

                for (int j = 0; j < id.ProtectionPsi.Length; j++)
                    id.ProtectionPsi[j] = Rom.ReadSByte();

                Rom.SeekAdd(0x13);

                id.Hp1 = Rom.ReadUShort();
                id.Hp2 = Rom.ReadUShort();

                Rom.SeekAdd(0x1A);

                Items[i] = id;
            }
        }

        public void Save()
        {
            Rom.Seek(Address + (index * Length));

            Rom.SeekAdd(4);

            Rom.WriteByte(this.ItemType);

            Rom.SeekAdd(3);

            Rom.WriteByte((byte)(this.KeyItem ? 0 : 1));

            Rom.SeekAdd(1);

            Rom.WriteUShort(this.Sell);
            Rom.WriteByte(this.EquipOwner);

            Rom.SeekAdd(3);

            Rom.WriteInt(this.Hp);
            Rom.WriteShort(this.Pp);

            Rom.SeekAdd(2);

            Rom.WriteSByte(this.Off);
            Rom.WriteSByte(this.Def);
            Rom.WriteSByte(this.Iq);
            Rom.WriteSByte(this.Speed);

            Rom.SeekAdd(4);

            for (int j = 0; j < this.ProtectionAilment.Length; j++)
                Rom.WriteShort(this.ProtectionAilment[j]);

            for (int j = 0; j < this.ProtectionPsi.Length; j++)
                Rom.WriteSByte(this.ProtectionPsi[j]);

            Rom.SeekAdd(0x13);

            Rom.WriteUShort(this.Hp1);
            Rom.WriteUShort(this.Hp2);

            M3Rom.IsModified = true;
        }
    }
}
