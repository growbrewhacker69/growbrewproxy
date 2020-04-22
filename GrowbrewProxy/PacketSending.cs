using System;
using System.Text;
using ENet.Managed;

namespace GrowbrewProxy
{
	// Token: 0x0200000E RID: 14
	public class PacketSending
	{
		// Token: 0x06000064 RID: 100 RVA: 0x00002415 File Offset: 0x00000615
		public static void SendData(byte[] data, ENetPeer peer, ENetPacketFlags flag = (ENetPacketFlags)1)
		{
			if (peer == null)
			{
				return;
			}
			if ((int)peer.State != 5)
			{
				return;
			}
			peer.Send(data, 0, flag);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00008210 File Offset: 0x00006410
		public static void SendPacketRaw(int type, byte[] data, ENetPeer peer, ENetPacketFlags flag = (ENetPacketFlags)1)
		{
			byte[] array = new byte[data.Length + 5];
			Array.Copy(BitConverter.GetBytes(type), array, 4);
			Array.Copy(data, 0, array, 4, data.Length);
			PacketSending.SendData(array, peer, (ENetPacketFlags)1);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000242E File Offset: 0x0000062E
		public static void SendPacket(int type, string str, ENetPeer peer, ENetPacketFlags flag = (ENetPacketFlags)1)
		{
			PacketSending.SendPacketRaw(type, Encoding.ASCII.GetBytes(str.ToCharArray()), peer, (ENetPacketFlags)1);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002448 File Offset: 0x00000648
		public static void SecondaryLogonAccepted(ENetPeer peer)
		{
			PacketSending.SendPacket(2, string.Empty, peer, (ENetPacketFlags)1);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002457 File Offset: 0x00000657
		public static void InitialLogonAccepted(ENetPeer peer)
		{
			PacketSending.SendPacket(1, string.Empty, peer, (ENetPacketFlags)1);
		}
	}
}
