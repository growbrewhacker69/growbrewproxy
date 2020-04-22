using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace GrowbrewProxy
{
	// Token: 0x0200001D RID: 29
	public class World : IDisposable
	{
		// Token: 0x0600008E RID: 142 RVA: 0x0000264E File Offset: 0x0000084E
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000265D File Offset: 0x0000085D
		protected virtual void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}
			if (disposing)
			{
				this.handle.Dispose();
				this.ResetAndInit();
			}
			this.disposed = true;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002683 File Offset: 0x00000883
		private void clearPlayers()
		{
			this.players.Clear();
			this.netID = 0;
			this.playerCount = 0;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00008D28 File Offset: 0x00006F28
		public int GetNetIDByName(string name)
		{
			foreach (Player player in this.players)
			{
				if (player.name == name)
				{
					return player.netID;
				}
			}
			return -1;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00008D90 File Offset: 0x00006F90
		public int GetUserIDByName(string name)
		{
			foreach (Player player in this.players)
			{
				if (player.name == name)
				{
					return player.userID;
				}
			}
			return -1;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00008DF8 File Offset: 0x00006FF8
		public Point GetPositionByNetID(int netID)
		{
			foreach (Player player in this.players)
			{
				if (player.netID == netID)
				{
					return new Point(player.X, player.Y);
				}
			}
			return new Point(-1, -1);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00008E6C File Offset: 0x0000706C
		private Point GetPlayerBtnLocation()
		{
			int num = 32;
			int num2 = 32;
			List<PlayerForm.ControlWithMetaData> controlsToLoad = PlayerForm.controlsToLoad;
			lock (controlsToLoad)
			{
				List<PlayerForm.ControlWithMetaData> controlsToLoad2 = PlayerForm.controlsToLoad;
				for (int i = 0; i < controlsToLoad2.Count; i++)
				{
					num2 += 64;
					if (num2 >= PlayerForm.updatedHeight - 100)
					{
						num2 = 32;
						num += 272;
					}
				}
			}
			return new Point(num, num2);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00008EEC File Offset: 0x000070EC
		public void AddPlayerControlToBox(Player pl)
		{
			List<PlayerForm.ControlWithMetaData> controlsToLoad = PlayerForm.controlsToLoad;
			lock (controlsToLoad)
			{
				PlayerForm.ControlWithMetaData item = default(PlayerForm.ControlWithMetaData);
				item.netID = pl.netID;
				item.control = new Button
				{
					Location = this.GetPlayerBtnLocation(),
					Text = pl.name.Substring(0, pl.name.Length - 2),
					Width = 128
				};
				PlayerForm.controlsToLoad.Add(item);
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00008F8C File Offset: 0x0000718C
		public void RemovePlayerControl(int netID)
		{
			List<PlayerForm.ControlWithMetaData> controlsToLoad = PlayerForm.controlsToLoad;
			List<PlayerForm.ControlWithMetaData> obj = controlsToLoad;
			lock (obj)
			{
				for (int i = 0; i < controlsToLoad.Count; i++)
				{
					if (controlsToLoad[i].netID == netID)
					{
						MainForm.LogText = string.Concat(new object[]
						{
							MainForm.LogText,
							"[",
							DateTime.UtcNow,
							"] (PROXY): Removed player from player control box with netID: ",
							netID.ToString(),
							"\n"
						});
						controlsToLoad.RemoveAt(i);
						break;
					}
				}
			}
			PlayerForm.requireClear = true;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00009040 File Offset: 0x00007240
		private void TileExtra_Serialize(byte[] dataPassed, int loc)
		{
			int num = this.readPos;
			this.readPos = num + 1;
			byte type = dataPassed[num];
			this.tiles[loc].type = type;
			switch (type)
			{
			case 1:
			{
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				this.readPos += (int)(num2 + 1);
				return;
			}
			case 2:
			{
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				this.readPos += (int)(num2 + 4);
				return;
			}
			case 3:
			{
				this.readPos++;
				byte b = dataPassed[this.readPos + 4];
				this.readPos += (int)(16 + b * 4);
				return;
			}
			case 4:
				this.readPos += 5;
				return;
			case 8:
				this.readPos++;
				return;
			case 9:
				this.readPos += 4;
				return;
			case 10:
				this.readPos += 5;
				return;
			case 11:
			{
				this.readPos += 4;
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				this.readPos += (int)num2;
				return;
			}
			case 14:
			{
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				this.readPos += (int)num2;
				this.readPos += 23;
				return;
			}
			case 15:
				this.readPos++;
				return;
			case 16:
				this.readPos++;
				return;
			case 18:
				this.readPos += 5;
				return;
			case 19:
				this.readPos += 18;
				return;
			case 20:
			{
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				this.readPos += (int)num2;
				return;
			}
			case 21:
			{
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				for (int i = 0; i < (int)num2; i++)
				{
					Tile[] array = this.tiles;
					string str = array[loc].str_1;
					num = this.readPos;
					this.readPos = num + 1;
					char c = (char)dataPassed[num];
					array[loc].str_1 = str + c.ToString();
				}
				this.readPos += 5;
				return;
			}
			case 23:
				this.readPos += 4;
				return;
			case 24:
				this.readPos += 8;
				return;
			case 25:
			{
				this.readPos++;
				int num3 = BitConverter.ToInt32(dataPassed, this.readPos);
				this.readPos += 4;
				this.readPos += 4 * num3;
				return;
			}
			case 27:
				this.readPos += 4;
				return;
			case 28:
				this.readPos += 6;
				return;
			case 32:
				this.readPos += 4;
				return;
			case 33:
				if (this.tiles[loc].fg == 3394)
				{
					short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
					this.readPos += 2;
					this.readPos += (int)num2;
					return;
				}
				break;
			case 35:
			{
				this.readPos += 4;
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				for (int j = 0; j < (int)num2; j++)
				{
					Tile[] array2 = this.tiles;
					string str2 = array2[loc].str_1;
					num = this.readPos;
					this.readPos = num + 1;
					char c = (char)dataPassed[num];
					array2[loc].str_1 = str2 + c.ToString();
				}
				return;
			}
			case 37:
			{
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				for (int k = 0; k < (int)num2; k++)
				{
					Tile[] array3 = this.tiles;
					string str3 = array3[loc].str_1;
					num = this.readPos;
					this.readPos = num + 1;
					char c = (char)dataPassed[num];
					array3[loc].str_1 = str3 + c.ToString();
				}
				this.readPos += 32;
				return;
			}
			case 39:
				this.readPos += 4;
				return;
			case 40:
				this.readPos += 4;
				return;
			case 42:
				this.readPos++;
				return;
			case 43:
				this.readPos += 16;
				return;
			case 44:
			{
				this.readPos++;
				this.readPos += 4;
				byte b2 = dataPassed[this.readPos];
				this.readPos += 4;
				this.readPos += (int)(b2 * 4);
				return;
			}
			case 47:
			{
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				for (int l = 0; l < (int)num2; l++)
				{
					Tile[] array4 = this.tiles;
					string str4 = array4[loc].str_1;
					num = this.readPos;
					this.readPos = num + 1;
					char c = (char)dataPassed[num];
					array4[loc].str_1 = str4 + c.ToString();
				}
				this.readPos += 5;
				return;
			}
			case 48:
			{
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				for (int m = 0; m < (int)num2; m++)
				{
					Tile[] array5 = this.tiles;
					string str5 = array5[loc].str_1;
					num = this.readPos;
					this.readPos = num + 1;
					char c = (char)dataPassed[num];
					array5[loc].str_1 = str5 + c.ToString();
				}
				this.readPos += 26;
				return;
			}
			case 49:
				this.readPos += 9;
				return;
			case 50:
				this.readPos += 4;
				return;
			case 54:
			{
				short num4 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				this.readPos += (int)num4;
				return;
			}
			case 56:
			{
				short num2 = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				for (int n = 0; n < (int)num2; n++)
				{
					Tile[] array6 = this.tiles;
					string str6 = array6[loc].str_1;
					num = this.readPos;
					this.readPos = num + 1;
					char c = (char)dataPassed[num];
					array6[loc].str_1 = str6 + c.ToString();
				}
				this.readPos += 4;
				return;
			}
			case 57:
				this.readPos += 4;
				return;
			case 62:
				this.readPos += 14;
				return;
			case 63:
			{
				int num5 = BitConverter.ToInt32(dataPassed, this.readPos);
				this.readPos += 4;
				this.readPos += num5 * 15;
				this.readPos += 8;
				return;
			}
			case 65:
				this.readPos += 17;
				return;
			case 66:
				this.readPos++;
				return;
			case 73:
				this.readPos += 4;
				return;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00009808 File Offset: 0x00007A08
		private int Tile_Serialize(byte[] dataPassed, int loc)
		{
			try
			{
				if (this.readPos >= dataPassed.Length)
				{
					return -1;
				}
				short num = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				this.tiles[loc].fg = num;
				short bg = BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				this.tiles[loc].bg = bg;
				int num2 = BitConverter.ToInt32(dataPassed, this.readPos);
				this.tiles[loc].tileState = num2;
				this.readPos += 4;
				if ((short)num2 > 0)
				{
					this.readPos += 2;
				}
				if (ItemDatabase.RequiresTileExtra((int)num))
				{
					this.TileExtra_Serialize(dataPassed, loc);
				}
			}
			catch (ArgumentException)
			{
				return -1;
			}
			this.tilesProperlySerialized++;
			return 0;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000098FC File Offset: 0x00007AFC
		private int WorldObjects_Serialize(byte[] dataPassed)
		{
			try
			{
				this.dropped.id = (int)BitConverter.ToInt16(dataPassed, this.readPos);
				this.readPos += 2;
				this.dropped.x = (float)BitConverter.ToInt32(dataPassed, this.readPos);
				this.readPos += 4;
				this.dropped.y = (float)BitConverter.ToInt32(dataPassed, this.readPos);
				this.readPos += 4;
				int num = this.readPos;
				this.readPos = num + 1;
				this.dropped.itemCount = dataPassed[num];
				this.dropped.uid = BitConverter.ToInt32(dataPassed, this.readPos);
				this.readPos += 4;
				MainForm.LogText = string.Concat(new object[]
				{
					MainForm.LogText,
					"[",
					DateTime.UtcNow,
					"] (PROXY): Serialized +1 dropped item object. ID: ",
					this.dropped.id.ToString(),
					" X:",
					this.dropped.x.ToString(),
					" Y: ",
					this.dropped.y.ToString(),
					" UID: ",
					this.dropped.uid.ToString(),
					"\n"
				});
			}
			catch (ArgumentException)
			{
				return -1;
			}
			catch (IndexOutOfRangeException)
			{
				return -2;
			}
			this.droppedItems.Add(this.dropped);
			this.dropped_TOTALUIDS++;
			return 0;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00009AC8 File Offset: 0x00007CC8
		private void ResetAndInit()
		{
			this.droppedItems.Clear();
			this.players.Clear();
			this.tiles = null;
			this.tilesProperlySerialized = 0;
			this.currentWorld = "";
			this.dropped_ITEMUID = -1;
			this.dropped_TOTALUIDS = 0;
			this.tileCount = 0;
			this.playerCount = 0;
			this.readPos = 0;
			this.netID = -1;
			this.width = 0;
			this.height = 0;
			PlayerForm.controlsToLoad.Clear();
			PlayerForm.requireClear = true;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00009B4C File Offset: 0x00007D4C
		public World LoadMap(byte[] packet)
		{
			try
			{
				this.ResetAndInit();
				byte[] array = VariantList.get_extended_data(packet);
				if (array.Length < 8192)
				{
					return this;
				}
				if (array.Length > 200000)
				{
					return this;
				}
				this.readPos += 6;
				short num = BitConverter.ToInt16(array, this.readPos);
				this.readPos += 2;
				for (int i = 0; i < (int)num; i++)
				{
					string str = this.currentWorld;
					byte[] array2 = array;
					int num2 = this.readPos;
					this.readPos = num2 + 1;
					char c = Convert.ToChar(array2[num2]);
					this.currentWorld = str + c.ToString();
				}
				this.width = BitConverter.ToInt32(array, this.readPos);
				this.readPos += 4;
				this.height = BitConverter.ToInt32(array, this.readPos);
				this.readPos += 4;
				this.tileCount = BitConverter.ToInt32(array, this.readPos);
				this.readPos += 4;
				this.tiles = new Tile[this.tileCount];
				MainForm.LogText = string.Concat(new object[]
				{
					MainForm.LogText,
					"[",
					DateTime.UtcNow,
					"] (PROXY): Loading world: ",
					this.currentWorld,
					", total tile count is: ",
					this.tileCount.ToString(),
					"\n"
				});
				int num3 = 0;
				while (num3 < this.tileCount && this.Tile_Serialize(array, num3) == 0)
				{
					num3++;
				}
				MainForm.LogText = string.Concat(new object[]
				{
					MainForm.LogText,
					"[",
					DateTime.UtcNow,
					"] (PROXY): [",
					this.currentWorld,
					"] Tiles properly serialized (without any errors): ",
					this.tilesProperlySerialized.ToString(),
					"\n"
				});
				if (this.readPos >= array.Length)
				{
					return this;
				}
				this.droppedItems.Clear();
				this.dropped_ITEMUID = BitConverter.ToInt32(array, this.readPos);
				this.readPos += 4;
				int num4 = BitConverter.ToInt32(array, this.readPos);
				this.readPos += 4;
				this.dropped_ITEMUID = num4;
				this.total_bytes_serialized = (ulong)((long)this.readPos);
				MainForm.LogText = string.Concat(new object[]
				{
					MainForm.LogText,
					"[",
					DateTime.UtcNow,
					"] (PROXY): Succeeded loading world '",
					this.currentWorld,
					"'! Total bytes serialized: ",
					this.total_bytes_serialized.ToString(),
					",  dropped item uid count: ",
					num4,
					"\n"
				});
			}
			catch (IndexOutOfRangeException)
			{
				return this;
			}
			return this;
		}

		// Token: 0x0400012C RID: 300
		private bool disposed;

		// Token: 0x0400012D RID: 301
		private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

		// Token: 0x0400012E RID: 302
		public List<Player> players = new List<Player>();

		// Token: 0x0400012F RID: 303
		public Player player = new Player();

		// Token: 0x04000130 RID: 304
		public Tile[] tiles;

		// Token: 0x04000131 RID: 305
		public List<DroppedObject> droppedItems = new List<DroppedObject>();

		// Token: 0x04000132 RID: 306
		private DroppedObject dropped;

		// Token: 0x04000133 RID: 307
		public int dropped_ITEMUID = -1;

		// Token: 0x04000134 RID: 308
		private int dropped_TOTALUIDS;

		// Token: 0x04000135 RID: 309
		internal int tilesProperlySerialized;

		// Token: 0x04000136 RID: 310
		public string currentWorld = "EXIT";

		// Token: 0x04000137 RID: 311
		private int width;

		// Token: 0x04000138 RID: 312
		private int height;

		// Token: 0x04000139 RID: 313
		public int playerCount;

		// Token: 0x0400013A RID: 314
		public int netID;

		// Token: 0x0400013B RID: 315
		public int userID;

		// Token: 0x0400013C RID: 316
		private int readPos;

		// Token: 0x0400013D RID: 317
		private int tileCount;

		// Token: 0x0400013E RID: 318
		internal ulong total_bytes_serialized;
	}
}
