using System;
using System.Collections.Generic;
using System.Text;

namespace GrowbrewProxy
{
	// Token: 0x02000013 RID: 19
	internal class GamePacketProton
	{
		// Token: 0x06000079 RID: 121 RVA: 0x000024FF File Offset: 0x000006FF
		public void AppendInt(int i)
		{
			this.objects.Add(i);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002512 File Offset: 0x00000712
		public void AppendUInt(uint ui)
		{
			this.objects.Add(ui);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002525 File Offset: 0x00000725
		public void AppendString(string s)
		{
			this.objects.Add(s);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002533 File Offset: 0x00000733
		public void AppendFloat(float v)
		{
			this.objects.Add(v);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002546 File Offset: 0x00000746
		public void AppendVector(GamePacketProton.Vector2 v)
		{
			this.objects.Add(v);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002559 File Offset: 0x00000759
		public void AppendVector(GamePacketProton.Vector3 v)
		{
			this.objects.Add(v);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000256C File Offset: 0x0000076C
		public void AppendRect(GamePacketProton.Rectf v)
		{
			this.objects.Add(v);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00008714 File Offset: 0x00006914
		public byte[] GetBytes()
		{
			byte[] array = new byte[61];
			array[0] = 4;
			array[4] = 1;
			Array.Copy(BitConverter.GetBytes(this.NetID), 0, array, 8, 4);
			Array.Copy(BitConverter.GetBytes(8), 0, array, 16, 4);
			if (this.delay > 0)
			{
				Array.Copy(BitConverter.GetBytes(this.delay), 0, array, 24, 4);
			}
			Array.Copy(BitConverter.GetBytes(this.objects.Count), 0, array, 56, 4);
			List<byte> list = new List<byte>();
			for (int i = 0; i < 61; i++)
			{
				list.Add(array[i]);
			}
			byte b = 0;
			foreach (object obj in this.objects)
			{
				if (obj is int)
				{
					byte[] array2 = new byte[6];
					Array.Copy(BitConverter.GetBytes((int)obj), 0, array2, 2, 4);
					array2[0] = b;
					array2[1] = 9;
					foreach (byte item in array2)
					{
						list.Add(item);
					}
				}
				else if (obj is uint)
				{
					byte[] array4 = new byte[6];
					Array.Copy(BitConverter.GetBytes((uint)obj), 0, array4, 2, 4);
					array4[0] = b;
					array4[1] = 5;
					foreach (byte item2 in array4)
					{
						list.Add(item2);
					}
				}
				else if (obj is string)
				{
					string s = (string)obj;
					byte[] bytes = Encoding.ASCII.GetBytes(s);
					byte[] array5 = new byte[2 + bytes.Length + 4];
					Array.Copy(BitConverter.GetBytes(bytes.Length), 0, array5, 2, 4);
					Array.Copy(bytes, 0, array5, 6, bytes.Length);
					array5[0] = b;
					array5[1] = 2;
					foreach (byte item3 in array5)
					{
						list.Add(item3);
					}
				}
				else if (obj is float)
				{
					byte[] array6 = new byte[6];
					Array.Copy(BitConverter.GetBytes((float)obj), 0, array6, 2, 4);
					array6[0] = b;
					array6[1] = 1;
					foreach (byte item4 in array6)
					{
						list.Add(item4);
					}
				}
				else if (obj is GamePacketProton.Vector2)
				{
					GamePacketProton.Vector2 vector = (GamePacketProton.Vector2)obj;
					byte[] array7 = new byte[10];
					byte[] bytes2 = BitConverter.GetBytes(vector.x);
					Array bytes3 = BitConverter.GetBytes(vector.y);
					Array.Copy(bytes2, 0, array7, 2, 4);
					Array.Copy(bytes3, 0, array7, 6, 4);
					array7[0] = b;
					array7[1] = 3;
					foreach (byte item5 in array7)
					{
						list.Add(item5);
					}
				}
				else
				{
					if (!(obj is GamePacketProton.Vector3))
					{
						throw new InvalidOperationException("Failed to write " + obj.GetType().ToString() + " object to packet data.");
					}
					GamePacketProton.Vector3 vector2 = (GamePacketProton.Vector3)obj;
					byte[] array8 = new byte[14];
					byte[] bytes4 = BitConverter.GetBytes(vector2.x);
					byte[] bytes5 = BitConverter.GetBytes(vector2.y);
					Array bytes6 = BitConverter.GetBytes(vector2.z);
					Array.Copy(bytes4, 0, array8, 2, 4);
					Array.Copy(bytes5, 0, array8, 6, 4);
					Array.Copy(bytes6, 0, array8, 10, 4);
					array8[0] = b;
					array8[1] = 4;
					foreach (byte item6 in array8)
					{
						list.Add(item6);
					}
				}
				b += 1;
			}
			list.Add(0);
			byte[] array9 = list.ToArray();
			array9[60] = b;
			return array9;
		}

		// Token: 0x04000101 RID: 257
		public List<object> objects = new List<object>();

		// Token: 0x04000102 RID: 258
		public int NetID = -1;

		// Token: 0x04000103 RID: 259
		public int delay;

		// Token: 0x02000014 RID: 20
		public struct Vector2
		{
			// Token: 0x06000082 RID: 130 RVA: 0x00002599 File Offset: 0x00000799
			public Vector2(float x_, float y_)
			{
				this.x = x_;
				this.y = y_;
			}

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000083 RID: 131 RVA: 0x000025A9 File Offset: 0x000007A9
			public GamePacketProton.Vector2 Zero
			{
				get
				{
					return new GamePacketProton.Vector2(0f, 0f);
				}
			}

			// Token: 0x04000104 RID: 260
			public float x;

			// Token: 0x04000105 RID: 261
			public float y;
		}

		// Token: 0x02000015 RID: 21
		public struct Vector3
		{
			// Token: 0x06000084 RID: 132 RVA: 0x000025BA File Offset: 0x000007BA
			public Vector3(float x_, float y_, float z_)
			{
				this.x = x_;
				this.y = y_;
				this.z = z_;
			}

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000085 RID: 133 RVA: 0x000025D1 File Offset: 0x000007D1
			public GamePacketProton.Vector3 Zero
			{
				get
				{
					return new GamePacketProton.Vector3(0f, 0f, 0f);
				}
			}

			// Token: 0x04000106 RID: 262
			public float x;

			// Token: 0x04000107 RID: 263
			public float y;

			// Token: 0x04000108 RID: 264
			public float z;
		}

		// Token: 0x02000016 RID: 22
		public struct Rectf
		{
			// Token: 0x06000086 RID: 134 RVA: 0x000025E7 File Offset: 0x000007E7
			public Rectf(float x_, float y_, float w_, float h_)
			{
				this.x = x_;
				this.y = y_;
				this.w = w_;
				this.h = h_;
			}

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000087 RID: 135 RVA: 0x00002606 File Offset: 0x00000806
			public GamePacketProton.Rectf Zero
			{
				get
				{
					return new GamePacketProton.Rectf(0f, 0f, 0f, 0f);
				}
			}

			// Token: 0x04000109 RID: 265
			public float x;

			// Token: 0x0400010A RID: 266
			public float y;

			// Token: 0x0400010B RID: 267
			public float w;

			// Token: 0x0400010C RID: 268
			public float h;
		}
	}
}
