using System;
using Extensions;

namespace MOTHER3
{
	// TODO: action order?
	// TODO: outside sprite!
	public class EnemyData : M3Rom
	{
		public static int Address = 0xD0D28;
		public static int Length = 144;
		public static int Entries = 256;
		public static EnemyData[] Enemies = new EnemyData[Entries];
		
		private int index;

		public ushort Bg;
		public ushort MusicSwirl;
		public ushort MusicBattle;
		public ushort MusicWin;

		public uint Hp;
		public uint Pp;
		public uint Exp;
		public uint Dp;
		public ushort Level;
		
		public byte Off;
		public byte Def;
		public byte Iq;
		public byte Speed;

		public byte OffBack;
		public byte DefBack;
		public byte IqBack;
		public byte SpeedBack;

		public ushort[] Weaknesses = new ushort[20];
		public ushort[] Action = new ushort[8];

		public byte TextEncounter;
		public byte TextDeath;

		public byte[] Item = new byte[3];
		public int[] ItemChance = new int[3];

		public static void Init()
		{
			Rom.Seek (Address);
			for (int i = 0; i < EnemyData.Entries; i++)
			{
				EnemyData e = new EnemyData();
				e.index = i;
				
				Rom.SeekAdd (0xA);

				e.Bg = Rom.ReadUShort();
				e.MusicSwirl = Rom.ReadUShort();
				e.MusicBattle = Rom.ReadUShort();
				e.MusicWin = Rom.ReadUShort();

				e.Level = Rom.ReadUShort ();
				e.Hp = Rom.ReadUInt ();
				e.Pp = Rom.ReadUInt ();
				e.Off = Rom.ReadByte ();
				e.Def = Rom.ReadByte ();
				e.Iq = Rom.ReadByte ();
				e.Speed = Rom.ReadByte ();
				
				Rom.SeekAdd (4);
				
				e.OffBack = Rom.ReadByte ();
				e.DefBack = Rom.ReadByte ();
				e.IqBack = Rom.ReadByte ();
				e.SpeedBack = Rom.ReadByte ();
				
				Rom.SeekAdd (4);

				for (int j = 0; j < e.Weaknesses.Length; j++)
					e.Weaknesses[j] = Rom.ReadUShort();

				for (int j = 0; j < e.Action.Length; j++)
					e.Action[j] = Rom.ReadUShort();

				Rom.SeekAdd(2);

				e.TextEncounter = Rom.ReadByte();
				e.TextDeath = Rom.ReadByte();

				Rom.SeekAdd(0x10);

				for (int j = 0; j < e.Item.Length; j++)
				{
					e.Item[j] = Rom.ReadByte();
					e.ItemChance[j] = Rom.Read24();
				}

				e.Exp = Rom.ReadUInt();
				e.Dp = Rom.ReadUInt();

				Rom.SeekAdd(4);

				Enemies[i] = e;
			}
		}

		public void Save()
		{
			Rom.Seek(Address + (index * Length));

			Rom.SeekAdd(0xA);

			Rom.WriteUShort(this.Bg);
			Rom.WriteUShort(this.MusicSwirl);
			Rom.WriteUShort(this.MusicBattle);
			Rom.WriteUShort(this.MusicWin);

			Rom.WriteUShort(this.Level);
			Rom.WriteUInt(this.Hp);
			Rom.WriteUInt(this.Pp);
			Rom.WriteByte(this.Off);
			Rom.WriteByte(this.Def);
			Rom.WriteByte(this.Iq);
			Rom.WriteByte(this.Speed);

			Rom.SeekAdd(4);

			Rom.WriteByte(this.OffBack);
			Rom.WriteByte(this.DefBack);
			Rom.WriteByte(this.IqBack);
			Rom.WriteByte(this.SpeedBack);

			Rom.SeekAdd(4);

			for (int j = 0; j < this.Weaknesses.Length; j++)
				Rom.WriteUShort(this.Weaknesses[j]);

			for (int j = 0; j < this.Action.Length; j++)
				Rom.WriteUShort(this.Action[j]);

			Rom.SeekAdd(2);
			
			Rom.WriteByte(this.TextEncounter);
			Rom.WriteByte(this.TextDeath);

			Rom.SeekAdd(0x10);

			for (int j = 0; j < this.Item.Length; j++)
			{
				Rom.WriteByte(this.Item[j]);
				Rom.Write24(this.ItemChance[j]);
			}

			Rom.WriteUInt(this.Exp);
			Rom.WriteUInt(this.Dp);

			M3Rom.IsModified = true;
		}
	}
}

