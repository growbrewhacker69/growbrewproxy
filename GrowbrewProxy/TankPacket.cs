using System;
using System.Collections.Generic;

namespace GrowbrewProxy
{
	// Token: 0x02000012 RID: 18
	internal class TankPacket
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000024CF File Offset: 0x000006CF
		public int CharacterState
		{
			get
			{
				return this.ExtDataMask;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000024D7 File Offset: 0x000006D7
		public int TilePlaced
		{
			get
			{
				return this.MainValue;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000024DF File Offset: 0x000006DF
		public int ExtDataSize
		{
			get
			{
				return this.ExtData.Count;
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00008484 File Offset: 0x00006684
		public byte[] PackForSendingRaw()
		{
			byte[] array = new byte[57 + this.ExtDataSize];
			Array.Copy(BitConverter.GetBytes(this.PacketType), array, 4);
			Array.Copy(BitConverter.GetBytes(this.NetID), 0, array, 4, 4);
			Array.Copy(BitConverter.GetBytes(this.SecondaryNetID), 0, array, 8, 4);
			Array.Copy(BitConverter.GetBytes(this.ExtDataMask), 0, array, 12, 4);
			Array.Copy(BitConverter.GetBytes(this.Padding), 0, array, 16, 4);
			Array.Copy(BitConverter.GetBytes(this.MainValue), 0, array, 20, 4);
			Array.Copy(BitConverter.GetBytes(this.X), 0, array, 24, 4);
			Array.Copy(BitConverter.GetBytes(this.Y), 0, array, 28, 4);
			Array.Copy(BitConverter.GetBytes(this.XSpeed), 0, array, 32, 4);
			Array.Copy(BitConverter.GetBytes(this.YSpeed), 0, array, 36, 4);
			Array.Copy(BitConverter.GetBytes(this.SecondaryPadding), 0, array, 40, 4);
			Array.Copy(BitConverter.GetBytes(this.PunchX), 0, array, 44, 4);
			Array.Copy(BitConverter.GetBytes(this.PunchY), 0, array, 48, 4);
			Array.Copy(BitConverter.GetBytes(this.ExtDataSize), 0, array, 52, 4);
			Array.Copy(this.ExtData.ToArray(), 0, array, 56, this.ExtData.Count);
			return array;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000085E4 File Offset: 0x000067E4
		public byte[] PackForSendingAsPacket()
		{
			byte[] array = this.PackForSendingRaw();
			byte[] array2 = new byte[array.Length + 4];
			Array.Copy(array, 0, array2, 4, array.Length);
			return array2;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00008610 File Offset: 0x00006810
		public static TankPacket Unpack(byte[] data)
		{
			return new TankPacket
			{
				PacketType = BitConverter.ToInt32(data, 0),
				NetID = BitConverter.ToInt32(data, 4),
				SecondaryNetID = BitConverter.ToInt32(data, 8),
				ExtDataMask = BitConverter.ToInt32(data, 12),
				Padding = (float)BitConverter.ToInt32(data, 16),
				MainValue = BitConverter.ToInt32(data, 20),
				X = BitConverter.ToSingle(data, 24),
				Y = BitConverter.ToSingle(data, 28),
				XSpeed = BitConverter.ToSingle(data, 32),
				YSpeed = BitConverter.ToSingle(data, 36),
				SecondaryPadding = (float)BitConverter.ToInt32(data, 40),
				PunchX = BitConverter.ToInt32(data, 44),
				PunchY = BitConverter.ToInt32(data, 48)
			};
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000086D8 File Offset: 0x000068D8
		public static TankPacket UnpackFromPacket(byte[] p)
		{
			TankPacket result = new TankPacket();
			if (p.Length >= 48)
			{
				byte[] array = new byte[p.Length - 4];
				Array.Copy(p, 4, array, 0, array.Length);
				result = TankPacket.Unpack(array);
			}
			return result;
		}

		// Token: 0x040000F2 RID: 242
		public int PacketType;

		// Token: 0x040000F3 RID: 243
		public int NetID;

		// Token: 0x040000F4 RID: 244
		public int SecondaryNetID;

		// Token: 0x040000F5 RID: 245
		public int ExtDataMask;

		// Token: 0x040000F6 RID: 246
		public float Padding;

		// Token: 0x040000F7 RID: 247
		public int MainValue;

		// Token: 0x040000F8 RID: 248
		public float X;

		// Token: 0x040000F9 RID: 249
		public float Y;

		// Token: 0x040000FA RID: 250
		public float XSpeed;

		// Token: 0x040000FB RID: 251
		public float YSpeed;

		// Token: 0x040000FC RID: 252
		public float SecondaryPadding;

		// Token: 0x040000FD RID: 253
		public int PunchX;

		// Token: 0x040000FE RID: 254
		public int PunchY;

		// Token: 0x040000FF RID: 255
		public List<byte> ExtData = new List<byte>();

		// Token: 0x04000100 RID: 256
		public byte[] ExtData_Alt;
	}
}
