using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GrowbrewProxy
{
	// Token: 0x02000017 RID: 23
	internal class VariantList
	{
		// Token: 0x06000088 RID: 136
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr memcpy(IntPtr dest, IntPtr src, UIntPtr count);

		// Token: 0x06000089 RID: 137 RVA: 0x00002621 File Offset: 0x00000821
		public static byte[] get_extended_data(byte[] pktData)
		{
			return pktData.Skip(56).ToArray<byte>();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00008AE4 File Offset: 0x00006CE4
		public static byte[] get_struct_data(byte[] package)
		{
			int num = package.Length;
			if (num >= 60)
			{
				byte[] array = new byte[num - 4];
				Buffer.BlockCopy(package, 4, array, 0, num - 4);
				int num2 = BitConverter.ToInt32(package, 56);
				if ((package[16] & 8) != 0)
				{
					if (num < num2 + 60)
					{
						MainForm.LogText = string.Concat(new object[]
						{
							MainForm.LogText,
							"[",
							DateTime.UtcNow,
							"] (PROXY): (ERROR) Too small extended packet to be valid!\n"
						});
					}
				}
				else
				{
					Buffer.BlockCopy(BitConverter.GetBytes(0), 0, package, 56, 4);
				}
				return array;
			}
			return null;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00008B74 File Offset: 0x00006D74
		public static VariantList.VarList GetCall(byte[] package)
		{
			VariantList.VarList varList = default(VariantList.VarList);
			int num = 0;
			byte b = package[num];
			num++;
			try
			{
				if (b > 7)
				{
					return varList;
				}
				varList.functionArgs = new object[(int)b];
				for (int i = 0; i < (int)b; i++)
				{
					varList.functionArgs[i] = 0;
					byte b2 = package[num];
					num++;
					byte b3 = package[num];
					num++;
					switch (b3)
					{
					case 1:
					{
						float num2 = BitConverter.ToUInt32(package, num);
						num += 4;
						varList.functionArgs[(int)b2] = num2;
						break;
					}
					case 2:
					{
						int num3 = BitConverter.ToInt32(package, num);
						num += 4;
						string text = string.Empty;
						text = Encoding.ASCII.GetString(package, num, num3);
						num += num3;
						if (b2 == 0)
						{
							varList.FunctionName = text;
						}
						if (b2 > 0)
						{
							if (varList.FunctionName == "OnSendToServer")
							{
								MainForm.doorid = text.Substring(text.IndexOf("|") + 1);
								if (text.Length >= 8)
								{
									text = text.Substring(0, text.IndexOf("|"));
								}
							}
							varList.functionArgs[(int)b2] = text;
						}
						break;
					}
					case 3:
					case 4:
						break;
					case 5:
					{
						uint num4 = BitConverter.ToUInt32(package, num);
						num += 4;
						varList.functionArgs[(int)b2] = num4;
						break;
					}
					default:
						if (b3 == 9)
						{
							int num5 = BitConverter.ToInt32(package, num);
							num += 4;
							varList.functionArgs[(int)b2] = num5;
						}
						break;
					}
				}
			}
			catch (Exception)
			{
			}
			return varList;
		}

		// Token: 0x02000018 RID: 24
		public struct VarList
		{
			// Token: 0x0400010D RID: 269
			public string FunctionName;

			// Token: 0x0400010E RID: 270
			public int netID;

			// Token: 0x0400010F RID: 271
			public uint delay;

			// Token: 0x04000110 RID: 272
			public object[] functionArgs;
		}

		// Token: 0x02000019 RID: 25
		public enum OnSendToServerArgs
		{
			// Token: 0x04000112 RID: 274
			port = 1,
			// Token: 0x04000113 RID: 275
			token,
			// Token: 0x04000114 RID: 276
			userId,
			// Token: 0x04000115 RID: 277
			IPWithExtraData
		}
	}
}
