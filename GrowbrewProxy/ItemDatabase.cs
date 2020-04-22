using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrowbrewProxy
{
	// Token: 0x02000002 RID: 2
	public class ItemDatabase
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002708 File Offset: 0x00000908
		public static ItemDatabase.ItemDefinition GetItemDef(int itemID)
		{
			if (itemID < 0 || itemID > ItemDatabase.itemDefs.Count<ItemDatabase.ItemDefinition>())
			{
				return ItemDatabase.itemDefs[0];
			}
			ItemDatabase.ItemDefinition itemDefinition = ItemDatabase.itemDefs[itemID];
			if ((int)itemDefinition.id != itemID)
			{
				foreach (ItemDatabase.ItemDefinition itemDefinition2 in ItemDatabase.itemDefs)
				{
					if ((int)itemDefinition2.id == itemID)
					{
						return itemDefinition2;
					}
				}
				return itemDefinition;
			}
			return itemDefinition;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002798 File Offset: 0x00000998
		public static bool RequiresTileExtra(int id)
		{
			ItemDatabase.ItemDefinition itemDef = ItemDatabase.GetItemDef(id);
			return itemDef.actionType == 2 || itemDef.actionType == 3 || itemDef.actionType == 10 || itemDef.actionType == 13 || itemDef.actionType == 19 || itemDef.actionType == 26 || itemDef.actionType == 33 || itemDef.actionType == 34 || itemDef.actionType == 36 || itemDef.actionType == 36 || itemDef.actionType == 38 || itemDef.actionType == 40 || itemDef.actionType == 43 || itemDef.actionType == 46 || itemDef.actionType == 47 || itemDef.actionType == 49 || itemDef.actionType == 50 || itemDef.actionType == 51 || itemDef.actionType == 52 || itemDef.actionType == 53 || itemDef.actionType == 54 || itemDef.actionType == 55 || itemDef.actionType == 56 || itemDef.id == 2246 || itemDef.actionType == 57 || itemDef.actionType == 59 || itemDef.actionType == 61 || itemDef.actionType == 62 || itemDef.actionType == 63 || itemDef.id == 3760 || itemDef.actionType == 66 || itemDef.actionType == 67 || itemDef.actionType == 73 || itemDef.actionType == 74 || itemDef.actionType == 76 || itemDef.actionType == 78 || itemDef.actionType == 80 || itemDef.actionType == 81 || itemDef.actionType == 83 || itemDef.actionType == 84 || itemDef.actionType == 85 || itemDef.actionType == 86 || itemDef.actionType == 87 || itemDef.actionType == 88 || itemDef.actionType == 89 || itemDef.actionType == 91 || itemDef.actionType == 93 || itemDef.actionType == 97 || itemDef.actionType == 100 || itemDef.actionType == 101 || itemDef.actionType == 111 || itemDef.actionType == 113 || itemDef.actionType == 115 || itemDef.actionType == 116 || itemDef.actionType == 127 || itemDef.actionType == 130 || (itemDef.id % 2 == 0 && itemDef.id >= 5818 && itemDef.id <= 5932);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002A9C File Offset: 0x00000C9C
		public void SetupItemDefs()
		{
			List<string> list = File.ReadAllText("include/base.txt").Split(new char[]
			{
				'|'
			}).ToList<string>();
			if (list.Count < 3)
			{
				return;
			}
			int num = -1;
			int.TryParse(list[2], out num);
			if (num == -1)
			{
				return;
			}
			short num2 = 0;
			ItemDatabase.itemDefs.Clear();
			ItemDatabase.ItemDefinition itemDefinition = default(ItemDatabase.ItemDefinition);
			using (StreamReader streamReader = File.OpenText("include/item_defs.txt"))
			{
				string text = string.Empty;
				while ((text = streamReader.ReadLine()) != null)
				{
					if (text.Length >= 2 && !text.Contains("//"))
					{
						List<string> list2 = text.Split(new char[]
						{
							'\\'
						}).ToList<string>();
						if (!(list2[0] != "add_item"))
						{
							itemDefinition.id = short.Parse(list2[1]);
							itemDefinition.actionType = byte.Parse(list2[4]);
							short id = itemDefinition.id;
							ItemDatabase.itemDefs.Add(itemDefinition);
							num2 += 1;
						}
					}
				}
			}
		}

		// Token: 0x04000001 RID: 1
		public static List<ItemDatabase.ItemDefinition> itemDefs = new List<ItemDatabase.ItemDefinition>();

		// Token: 0x02000003 RID: 3
		public struct ItemDefinition
		{
			// Token: 0x04000002 RID: 2
			public short id;

			// Token: 0x04000003 RID: 3
			public byte editType;

			// Token: 0x04000004 RID: 4
			public byte editCategory;

			// Token: 0x04000005 RID: 5
			public byte actionType;

			// Token: 0x04000006 RID: 6
			public byte hitSound;

			// Token: 0x04000007 RID: 7
			public string itemName;

			// Token: 0x04000008 RID: 8
			public string fileName;

			// Token: 0x04000009 RID: 9
			public int texHash;

			// Token: 0x0400000A RID: 10
			public byte itemKind;

			// Token: 0x0400000B RID: 11
			public byte texX;

			// Token: 0x0400000C RID: 12
			public byte texY;

			// Token: 0x0400000D RID: 13
			public byte sprType;

			// Token: 0x0400000E RID: 14
			public byte isStripey;

			// Token: 0x0400000F RID: 15
			public byte collType;

			// Token: 0x04000010 RID: 16
			public byte hitsTaken;

			// Token: 0x04000011 RID: 17
			public byte dropChance;

			// Token: 0x04000012 RID: 18
			public int clothingType;

			// Token: 0x04000013 RID: 19
			public short rarity;

			// Token: 0x04000014 RID: 20
			public short toolKind;

			// Token: 0x04000015 RID: 21
			public string audioFile;

			// Token: 0x04000016 RID: 22
			public int audioHash;

			// Token: 0x04000017 RID: 23
			public short audioVol;

			// Token: 0x04000018 RID: 24
			public byte seedBase;

			// Token: 0x04000019 RID: 25
			public byte seedOver;

			// Token: 0x0400001A RID: 26
			public byte treeBase;

			// Token: 0x0400001B RID: 27
			public byte treeOver;

			// Token: 0x0400001C RID: 28
			public byte color1R;

			// Token: 0x0400001D RID: 29
			public byte color1G;

			// Token: 0x0400001E RID: 30
			public byte color1B;

			// Token: 0x0400001F RID: 31
			public byte color1A;

			// Token: 0x04000020 RID: 32
			public byte color2R;

			// Token: 0x04000021 RID: 33
			public byte color2G;

			// Token: 0x04000022 RID: 34
			public byte color2B;

			// Token: 0x04000023 RID: 35
			public byte color2A;

			// Token: 0x04000024 RID: 36
			public short ing1;

			// Token: 0x04000025 RID: 37
			public short ing2;

			// Token: 0x04000026 RID: 38
			public int growTime;

			// Token: 0x04000027 RID: 39
			public string extraUnk01;

			// Token: 0x04000028 RID: 40
			public string extraUnk02;

			// Token: 0x04000029 RID: 41
			public string extraUnk03;

			// Token: 0x0400002A RID: 42
			public string extraUnk04;

			// Token: 0x0400002B RID: 43
			public string extraUnk05;

			// Token: 0x0400002C RID: 44
			public string extraUnk11;

			// Token: 0x0400002D RID: 45
			public string extraUnk12;

			// Token: 0x0400002E RID: 46
			public string extraUnk13;

			// Token: 0x0400002F RID: 47
			public string extraUnk14;

			// Token: 0x04000030 RID: 48
			public string extraUnk15;

			// Token: 0x04000031 RID: 49
			public short extraUnkShort1;

			// Token: 0x04000032 RID: 50
			public short extraUnkShort2;

			// Token: 0x04000033 RID: 51
			public int extraUnkInt1;
		}
	}
}
