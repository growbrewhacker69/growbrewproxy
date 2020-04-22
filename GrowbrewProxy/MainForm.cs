using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ENet.Managed;

namespace GrowbrewProxy
{
	// Token: 0x02000004 RID: 4
	public partial class MainForm : Form
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002066 File Offset: 0x00000266
		public MainForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002BC8 File Offset: 0x00000DC8
		public static string GenerateRID()
		{
			string str = "0";
			Random random = new Random();
			return str + new string((from s in Enumerable.Repeat<string>("ABCDEF0123456789", 31)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002C18 File Offset: 0x00000E18
		public static string GenerateUniqueWinKey()
		{
			string str = "7";
			Random random = new Random();
			return str + new string((from s in Enumerable.Repeat<string>("ABCDEF0123456789", 31)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002C68 File Offset: 0x00000E68
		public static string GenerateMACAddress()
		{
			Random random = new Random();
			byte[] array = new byte[6];
			random.NextBytes(array);
			array[0] = Convert.ToByte((array[0] & 254));
			StringBuilder stringBuilder = new StringBuilder(18);
			foreach (byte b in array)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(":");
				}
				stringBuilder.Append(string.Format("%02x", b));
			}
			return stringBuilder.ToString().ToLower();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002CEC File Offset: 0x00000EEC
		public static string CreateLogonPacket(bool hasGrowId = false)
		{
			string text = string.Empty;
			Random random = new Random();
			bool flag = false;
			if (MainForm.token > 0 || MainForm.token < 0)
			{
				flag = true;
			}
			if (hasGrowId)
			{
				text = text + "tankIDName|" + MainForm.tankIDName + "\n";
				text = text + "tankIDPass|" + MainForm.tankIDPass + "\n";
			}
			text = text + "requestedName|Growbrew" + random.Next(0, 255).ToString() + "\n";
			text += "f|1\n";
			text += "protocol|94\n";
			text = text + "game_version|" + MainForm.game_version + "\n";
			if (flag)
			{
				text = string.Concat(new object[]
				{
					text,
					"lmode|",
					MainForm.lmode,
					"\n"
				});
			}
			text += "cbits|0\n";
			text += "player_age|100\n";
			text += "GDPR|1\n";
			text += "hash2|231337357\n";
			text += "meta|localhost\n";
			text += "fhash|-716928004\n";
			text = text + "rid|" + MainForm.GenerateRID() + "\n";
			text += "platformID|1\n";
			text += "deviceVersion|0\n";
			text = text + "country|" + MainForm.country + "\n";
			text += "hash|-481288825\n";
			text = text + "mac|" + MainForm.macc + "\n";
			if (flag)
			{
				text = text + "user|" + MainForm.userID.ToString() + "\n";
			}
			if (flag)
			{
				text = text + "token|" + MainForm.token.ToString() + "\n";
			}
			if (MainForm.doorid != "")
			{
				text = text + "doorID|" + MainForm.doorid.ToString() + "\n";
			}
			return text + "wk|NONE0\n";
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002EF0 File Offset: 0x000010F0
		private void AppendLog(string text)
		{
			if (text == string.Empty)
			{
				return;
			}
			if (this.logBox.InvokeRequired)
			{
				this.logBox.Invoke(new MainForm.SafeCallDelegate(this.AppendLog), new object[]
				{
					text
				});
				return;
			}
			RichTextBox richTextBox = this.logBox;
			richTextBox.Text = richTextBox.Text + text + "\n";
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002F58 File Offset: 0x00001158
		public static void ConnectToServer()
		{
			if (MainForm.realPeer == null)
			{
				MainForm.realPeer = MainForm.client.Connect(new IPEndPoint(IPAddress.Parse(MainForm.Growtopia_IP), MainForm.Growtopia_Port), 1, 0U);
				return;
			}
			if (MainForm.realPeer.State != (ENetPeerState)5)
			{
				MainForm.realPeer = MainForm.client.Connect(new IPEndPoint(IPAddress.Parse(MainForm.Growtopia_IP), MainForm.Growtopia_Port), 1, 0U);
				return;
			}
			PacketSending.SendPacket(3, "action|quit", MainForm.realPeer, (ENetPacketFlags)1);
			MainForm.realPeer = MainForm.client.Connect(new IPEndPoint(IPAddress.Parse(MainForm.Growtopia_IP), MainForm.Growtopia_Port), 1, 0U);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002FFC File Offset: 0x000011FC
		private void Host_OnConnect(object sender, ENetConnectEventArgs e)
		{
			MainForm.proxyPeer = e.Peer;
			e.Peer.OnReceive += this.Peer_OnReceive;
			e.Peer.OnDisconnect += this.Peer_OnDisconnect;
			this.AppendLog("A new client connected from {0} " + e.Peer.RemoteEndPoint);
			e.Peer.Timeout(30000U, 25000U, 30000U);
			this.AppendLog("Connecting to gt servers...");
			MainForm.ConnectToServer();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000207F File Offset: 0x0000027F
		private void Peer_OnDisconnect(object sender, uint e)
		{
			MainForm.messageHandler.enteredGame = false;
			this.AppendLog("An internal disconnection was triggered in the proxy, you may want to reconnect your GT Client if you are not being disconnected by default (maybe because of sub-server switching?)");
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002097 File Offset: 0x00000297
		private void Peer_OnReceive(object sender, ENetPacket e)
		{
			this.AppendLog(MainForm.messageHandler.HandlePacketFromClient(e));
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020AA File Offset: 0x000002AA
		private void Peer_OnReceive_Client(object sender, ENetPacket e)
		{
			this.AppendLog(MainForm.messageHandler.HandlePacketFromServer(e));
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002050 File Offset: 0x00000250
		private void Peer_OnDisconnect_Client(object sender, uint e)
		{
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000020BD File Offset: 0x000002BD
		private void loadLogs(bool requireReloadFromFile = false)
		{
			if (requireReloadFromFile)
			{
				MainForm.LogText = File.ReadAllText("debuglog.txt");
				this.entireLog.Text = MainForm.LogText;
				return;
			}
			this.entireLog.Text = MainForm.LogText;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000020F2 File Offset: 0x000002F2
		private void Client_OnConnect(object sender, ENetConnectEventArgs e)
		{
			e.Peer.OnReceive += this.Peer_OnReceive_Client;
			e.Peer.OnDisconnect += this.Peer_OnDisconnect_Client;
			this.AppendLog("The growtopia client just connected successfully.");
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003088 File Offset: 0x00001288
		private void LaunchProxy()
		{
			if (!this.srvRunning)
			{
				this.srvRunning = true;
				this.clientRunning = true;
				this.m_Host = new ENetHost(new IPEndPoint(IPAddress.Any, 2), 512, 10);
				this.m_Host.OnConnect += this.Host_OnConnect;
				this.m_Host.ChecksumWithCRC32();
				this.m_Host.CompressWithRangeCoder();
				this.m_Host.StartServiceThread();
				MainForm.client = new ENetHost(512, 10);
				MainForm.client.OnConnect += this.Client_OnConnect;
				MainForm.client.ChecksumWithCRC32();
				MainForm.client.CompressWithRangeCoder();
				MainForm.client.StartServiceThread();
				this.runproxy.Enabled = false;
				this.labelsrvrunning.Text = "Server is running!";
				this.labelsrvrunning.ForeColor = Color.Green;
				this.labelclientrunning.Text = "Client is running!";
				this.labelclientrunning.ForeColor = Color.Green;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003194 File Offset: 0x00001394
		private void runproxy_Click(object sender, EventArgs e)
		{
			if (this.ipaddrBox.Text != "" && this.portBox.Text != "")
			{
				MainForm.Growtopia_IP = this.ipaddrBox.Text;
				MainForm.Growtopia_Port = Convert.ToInt32(this.portBox.Text);
			}
			this.LaunchProxy();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000212D File Offset: 0x0000032D
		private void MainForm_Load(object sender, EventArgs e)
		{
			this.playerLogicUpdate.Start();
			this.itemDB.SetupItemDefs();
			LibENet.Load();
			LibENet.Initialize.Invoke();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002155 File Offset: 0x00000355
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.srvRunning = false;
			this.clientRunning = false;
			Environment.Exit(0);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002050 File Offset: 0x00000250
		private void logBox_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002050 File Offset: 0x00000250
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000031FC File Offset: 0x000013FC
		private void formTabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Form.ActiveForm == null)
			{
				return;
			}
			if (this.formTabs.SelectedTab == this.formTabs.TabPages["proxyPage"])
			{
				Form.ActiveForm.Text = "Growbrew Proxy - Main Page";
				return;
			}
			if (this.formTabs.SelectedTab == this.formTabs.TabPages["cheatPage"])
			{
				Form.ActiveForm.Text = "Growbrew Proxy - Cheats and more";
				return;
			}
			if (this.formTabs.SelectedTab == this.formTabs.TabPages["extraPage"])
			{
				this.loadLogs(false);
				Form.ActiveForm.Text = "Growbrew Proxy - Logs";
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000216B File Offset: 0x0000036B
		private void reloadLogs_Click(object sender, EventArgs e)
		{
			this.loadLogs(false);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000032B0 File Offset: 0x000014B0
		private void button1_Click_1(object sender, EventArgs e)
		{
			if (this.ipaddrBox.Text != "" && this.portBox.Value != 0m)
			{
				MainForm.token = 0;
				MainForm.Growtopia_IP = this.ipaddrBox.Text;
				MainForm.Growtopia_Port = (int)this.portBox.Value;
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002174 File Offset: 0x00000374
		private void button2_Click(object sender, EventArgs e)
		{
			MainForm.realPeer.DisconnectNow(0U);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003318 File Offset: 0x00001518
		private void changeNameBox_TextChanged(object sender, EventArgs e)
		{
			GamePacketProton gamePacketProton = new GamePacketProton();
			gamePacketProton.AppendString("OnNameChanged");
			gamePacketProton.AppendString("`w" + this.changeNameBox.Text + "``");
			gamePacketProton.NetID = MainForm.messageHandler.worldMap.netID;
			PacketSending.SendData(gamePacketProton.GetBytes(), MainForm.proxyPeer, (ENetPacketFlags)1);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000337C File Offset: 0x0000157C
		private void doRGBHack()
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			while (this.rgbSkinHack.Checked)
			{
				Thread.Sleep(32);
				MainForm.skinColor[0] = byte.MaxValue;
				if (!flag4)
				{
					if (MainForm.skinColor[1] < 255)
					{
						byte[] array = MainForm.skinColor;
						int num = 1;
						array[num] += 1;
					}
					else
					{
						flag = true;
					}
					if (flag)
					{
						if (MainForm.skinColor[2] < 255)
						{
							byte[] array2 = MainForm.skinColor;
							int num2 = 2;
							array2[num2] += 1;
						}
						else
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						if (MainForm.skinColor[3] < 255)
						{
							byte[] array3 = MainForm.skinColor;
							int num3 = 3;
							array3[num3] += 1;
						}
						else
						{
							flag3 = true;
						}
					}
					if (flag3)
					{
						flag4 = true;
					}
				}
				else
				{
					if (MainForm.skinColor[3] > 0)
					{
						byte[] array4 = MainForm.skinColor;
						int num4 = 3;
						array4[num4] -= 1;
					}
					else
					{
						flag = false;
					}
					if (!flag)
					{
						if (MainForm.skinColor[2] > 0)
						{
							byte[] array5 = MainForm.skinColor;
							int num5 = 2;
							array5[num5] -= 1;
						}
						else
						{
							flag2 = false;
						}
					}
					if (!flag2)
					{
						if (MainForm.skinColor[1] > 0)
						{
							byte[] array6 = MainForm.skinColor;
							int num6 = 1;
							array6[num6] -= 1;
						}
						else
						{
							flag3 = false;
						}
					}
					if (!flag3)
					{
						flag4 = false;
					}
				}
				GamePacketProton gamePacketProton = new GamePacketProton();
				gamePacketProton.AppendString("OnChangeSkin");
				gamePacketProton.AppendUInt(BitConverter.ToUInt32(MainForm.skinColor, 0));
				gamePacketProton.NetID = MainForm.messageHandler.worldMap.netID;
				PacketSending.SendData(gamePacketProton.GetBytes(), MainForm.proxyPeer, (ENetPacketFlags)1);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002181 File Offset: 0x00000381
		private void rgbSkinHack_CheckedChanged(object sender, EventArgs e)
		{
			MainForm.cheat_rgbSkin = !MainForm.cheat_rgbSkin;
			if (this.rgbSkinHack.Checked)
			{
				new Thread(new ThreadStart(this.doRGBHack)).Start();
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000021B3 File Offset: 0x000003B3
		private void hack_magplant_CheckedChanged(object sender, EventArgs e)
		{
			MainForm.cheat_magplant = !MainForm.cheat_magplant;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000021C2 File Offset: 0x000003C2
		private void showExternals()
		{
			this.explanatoryLabel.Visible = false;
			this.showExternalsbtn.Visible = false;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000021DC File Offset: 0x000003DC
		private void showExternalsbtn_Click(object sender, EventArgs e)
		{
			this.showExternals();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000021E4 File Offset: 0x000003E4
		private void button3_Click(object sender, EventArgs e)
		{
			MainForm.pForm.Text = "All players in " + MainForm.messageHandler.worldMap.currentWorld;
			MainForm.pForm.ShowDialog();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002214 File Offset: 0x00000414
		private void aboutlabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://github.com/N-a-h");
			
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000222C File Offset: 0x0000042C
		private void hack_autoworldbanmod_CheckedChanged(object sender, EventArgs e)
		{
			MainForm.cheat_autoworldban_mod = !MainForm.cheat_autoworldban_mod;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000034E0 File Offset: 0x000016E0
		private void button1_Click_2(object sender, EventArgs e)
		{
			try
			{
				TankPacket tankPacket = new TankPacket();
				tankPacket.PacketType = 11;
				if (MainForm.messageHandler.worldMap != null)
				{
					this.custom_collect_x.Text = MainForm.messageHandler.worldMap.player.X.ToString();
					this.custom_collect_y.Text = MainForm.messageHandler.worldMap.player.Y.ToString();
					tankPacket.X = (float)int.Parse(this.custom_collect_x.Text);
					tankPacket.Y = (float)int.Parse(this.custom_collect_y.Text);
					tankPacket.MainValue = int.Parse(this.custom_collect_uid.Text);
					PacketSending.SendPacketRaw(4, tankPacket.PackForSendingRaw(), MainForm.realPeer, (ENetPacketFlags)1);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000035C0 File Offset: 0x000017C0
		private void playerLogicUpdate_Tick(object sender, EventArgs e)
		{
			if (MainForm.messageHandler.worldMap != null)
			{
				Player player = MainForm.messageHandler.worldMap.player;
				this.posXYLabel.Text = "X: " + player.X.ToString() + " Y: " + player.Y.ToString();
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000361C File Offset: 0x0000181C
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			MainForm.cheat_speedy = !MainForm.cheat_speedy;
			TankPacket tankPacket = new TankPacket();
			tankPacket.PacketType = 20;
			tankPacket.X = 1000f;
			tankPacket.Y = 300f;
			tankPacket.YSpeed = 1000f;
			tankPacket.NetID = MainForm.messageHandler.worldMap.netID;
			if (this.cheat_speed.Checked)
			{
				tankPacket.XSpeed = 100000f;
			}
			else
			{
				tankPacket.XSpeed = 300f;
			}
			byte[] array = tankPacket.PackForSendingRaw();
			Buffer.BlockCopy(BitConverter.GetBytes(8487168), 0, array, 1, 3);
			PacketSending.SendPacketRaw(4, array, MainForm.proxyPeer, (ENetPacketFlags)1);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000036C8 File Offset: 0x000018C8
		private void button3_Click_1(object sender, EventArgs e)
		{
			int num = 0;
			foreach (Player player in MainForm.messageHandler.worldMap.players)
			{
				if (player.name.Contains(this.nameBoxOn.Text))
				{
					num = player.netID;
					break;
				}
			}
			PacketSending.SendPacket(2, "action|wrench\nnetid|" + num.ToString(), MainForm.realPeer, (ENetPacketFlags)1);
			PacketSending.SendPacket(2, string.Concat(new string[]
			{
				"action|dialog_return\ndialog_name|popup\nnetID|",
				num.ToString(),
				"|\nbuttonClicked|",
				this.actionButtonClicked.Text,
				"\n"
			}), MainForm.realPeer, (ENetPacketFlags)1);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002050 File Offset: 0x00000250
		private void sendAction_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000223B File Offset: 0x0000043B
		private void macUpdate_Click(object sender, EventArgs e)
		{
			MainForm.macc = this.setMac.Text;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000037A4 File Offset: 0x000019A4
		private void button3_Click_2(object sender, EventArgs e)
		{
			PacketSending.SendPacket(2, string.Concat(new string[]
			{
				"action|dialog_return\ndialog_name|storageboxxtreme\ntilex|",
				this.tileX.ToString(),
				"|\ntiley|",
				this.tileY.ToString(),
				"|\nitemid|1|\nbuttonClicked|cancel\nitemcount|1\n"
			}), MainForm.realPeer, (ENetPacketFlags)1);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000224D File Offset: 0x0000044D
		private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
		{
			MainForm.bypassAAP = !MainForm.bypassAAP;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000037FC File Offset: 0x000019FC
		private void ghostmodskin_CheckedChanged(object sender, EventArgs e)
		{
			if (this.ghostmodskin.Checked)
			{
				MainForm.skinColor[0] = 110;
				MainForm.skinColor[1] = byte.MaxValue;
				MainForm.skinColor[2] = byte.MaxValue;
				MainForm.skinColor[3] = byte.MaxValue;
				GamePacketProton gamePacketProton = new GamePacketProton();
				gamePacketProton.AppendString("OnChangeSkin");
				gamePacketProton.AppendUInt(BitConverter.ToUInt32(MainForm.skinColor, 0));
				gamePacketProton.NetID = MainForm.messageHandler.worldMap.netID;
				PacketSending.SendData(gamePacketProton.GetBytes(), MainForm.proxyPeer, (ENetPacketFlags)1);
				return;
			}
			MainForm.skinColor[0] = byte.MaxValue;
			GamePacketProton gamePacketProton2 = new GamePacketProton();
			gamePacketProton2.AppendString("OnChangeSkin");
			gamePacketProton2.AppendUInt(BitConverter.ToUInt32(MainForm.skinColor, 0));
			gamePacketProton2.NetID = MainForm.messageHandler.worldMap.netID;
			PacketSending.SendData(gamePacketProton2.GetBytes(), MainForm.proxyPeer, (ENetPacketFlags)1);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000225C File Offset: 0x0000045C
		private void button5_Click(object sender, EventArgs e)
		{
			if (this.send2client.Checked)
			{
				PacketSending.SendPacket(3, this.packetText.Text, MainForm.proxyPeer, (ENetPacketFlags)1);
				return;
			}
			PacketSending.SendPacket(3, this.packetText.Text, MainForm.realPeer, (ENetPacketFlags)1);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000229A File Offset: 0x0000049A
		private void button4_Click(object sender, EventArgs e)
		{
			if (this.send2client.Checked)
			{
				PacketSending.SendPacket(2, this.packetText.Text, MainForm.proxyPeer, (ENetPacketFlags)1);
				return;
			}
			PacketSending.SendPacket(2, this.packetText.Text, MainForm.realPeer, (ENetPacketFlags)1);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002050 File Offset: 0x00000250
		private void actionButtonClicked_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002050 File Offset: 0x00000250
		private void nameBoxOn_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000038DC File Offset: 0x00001ADC
		private void button4_Click_1(object sender, EventArgs e)
		{
			TankPacket tankPacket = new TankPacket();
			tankPacket.PacketType = 3;
			for (int i = 0; i < 100; i++)
			{
				tankPacket.PunchX = i;
				tankPacket.PunchY = i;
				tankPacket.ExtDataMask = 838338258;
				PacketSending.SendPacketRaw(4, tankPacket.PackForSendingRaw(), MainForm.realPeer, (ENetPacketFlags)1);
				tankPacket.PacketType = 0;
				PacketSending.SendPacketRaw(4, tankPacket.PackForSendingRaw(), MainForm.realPeer, (ENetPacketFlags)1);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000022D8 File Offset: 0x000004D8
		private void button5_Click_1(object sender, EventArgs e)
		{
			PacketSending.SendPacket(2, "action|input|?", MainForm.realPeer, (ENetPacketFlags)1);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003948 File Offset: 0x00001B48
		private void button6_Click(object sender, EventArgs e)
		{
			string text = "";
			for (int i = 0; i < 100000; i++)
			{
				text += "a";
			}
			PacketSending.SendPacket(2, text, MainForm.realPeer, (ENetPacketFlags)1);
			MessageBox.Show("Sent packet!");
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000022EB File Offset: 0x000004EB
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			MainForm.blockEnterGame = !MainForm.blockEnterGame;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003990 File Offset: 0x00001B90
		private void doTheNukaz()
		{
			while (this.checkBox3.Checked)
			{
				if (MainForm.realPeer != null)
				{
					if (MainForm.realPeer.State != (ENetPeerState)5)
					{
						return;
					}
					for (int i = 0; i < 3; i++)
					{
						int num = MainForm.messageHandler.worldMap.player.X / 32;
						int num2 = MainForm.messageHandler.worldMap.player.Y / 32;
						if (!this.checkBox5.Checked)
						{
							if (i == 0)
							{
								num++;
							}
							else if (i == 1)
							{
								num--;
							}
							else if (i == 2)
							{
								num2--;
							}
							if (this.checkBox4.Checked && i == 3)
							{
								num2++;
							}
						}
						else
						{
							if (i == 1)
							{
								num--;
							}
							if (i == 2)
							{
								num -= 2;
							}
						}
						Thread.Sleep(176);
						TankPacket tankPacket = new TankPacket();
						tankPacket.PunchX = num;
						tankPacket.PunchY = num2;
						tankPacket.MainValue = 18;
						tankPacket.X = (float)MainForm.messageHandler.worldMap.player.X;
						tankPacket.Y = (float)MainForm.messageHandler.worldMap.player.Y;
						tankPacket.ExtDataMask &= -5;
						tankPacket.ExtDataMask &= -65;
						tankPacket.ExtDataMask &= -65537;
						tankPacket.NetID = -1;
						PacketSending.SendPacketRaw(4, tankPacket.PackForSendingRaw(), MainForm.realPeer, (ENetPacketFlags)1);
						tankPacket.NetID = -1;
						tankPacket.PacketType = 3;
						tankPacket.ExtDataMask = 0;
						PacketSending.SendPacketRaw(4, tankPacket.PackForSendingRaw(), MainForm.realPeer, (ENetPacketFlags)1);
					}
				}
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000022FA File Offset: 0x000004FA
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox3.Checked)
			{
				new Thread(new ThreadStart(this.doTheNukaz)).Start();
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000231F File Offset: 0x0000051F
		private string filterOutAllBadChars(string str)
		{
			return Regex.Replace(str, "[^a-zA-Z0-9\\-]", "");
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003B28 File Offset: 0x00001D28
		private void button7_Click(object sender, EventArgs e)
		{
			foreach (Player player in MainForm.messageHandler.worldMap.players)
			{
				PacketSending.SendPacket(2, "action|input\n|text|/pull " + player.name.Substring(2, player.name.Length - 4), MainForm.realPeer, (ENetPacketFlags)1);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003BAC File Offset: 0x00001DAC
		private void button8_Click(object sender, EventArgs e)
		{
			foreach (Player player in MainForm.messageHandler.worldMap.players)
			{
				PacketSending.SendPacket(2, "action|input\n|text|/ban " + player.name.Substring(2, player.name.Length - 4), MainForm.realPeer, (ENetPacketFlags)1);
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003C30 File Offset: 0x00001E30
		private void button9_Click(object sender, EventArgs e)
		{
			foreach (Player player in MainForm.messageHandler.worldMap.players)
			{
				PacketSending.SendPacket(2, "action|input\n|text|/kick " + player.name.Substring(2, player.name.Length - 4), MainForm.realPeer, (ENetPacketFlags)1);
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003CB4 File Offset: 0x00001EB4
		private void button10_Click(object sender, EventArgs e)
		{
			foreach (Player player in MainForm.messageHandler.worldMap.players)
			{
				PacketSending.SendPacket(2, "action|input\n|text|/trade " + player.name.Substring(2, player.name.Length - 4), MainForm.realPeer, (ENetPacketFlags)1);
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003D38 File Offset: 0x00001F38
		private void button11_Click(object sender, EventArgs e)
		{
			MainForm.isHTTPRunning = !MainForm.isHTTPRunning;
			if (MainForm.isHTTPRunning)
			{
				HTTPServer.StartHTTP(new string[]
				{
					"http://*:80/"
				});
				this.button11.Text = "Stop HTTP Server";
				this.label13.Visible = true;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002331 File Offset: 0x00000531
		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			MainForm.skipCache = !MainForm.skipCache;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002340 File Offset: 0x00000540
		private void button12_Click(object sender, EventArgs e)
		{
			MainForm.game_version = this.textBox2.Text;
		}

		// Token: 0x04000034 RID: 52
		private static bool isHTTPRunning = false;

		// Token: 0x04000035 RID: 53
		public static PlayerForm pForm = new PlayerForm();

		// Token: 0x04000036 RID: 54
		public static bool skipCache = false;

		// Token: 0x04000037 RID: 55
		public static string LogText = string.Empty;

		// Token: 0x04000038 RID: 56
		private static ENetHost client;

		// Token: 0x04000039 RID: 57
		private ENetHost m_Host;

		// Token: 0x0400003A RID: 58
		public static ENetPeer realPeer;

		// Token: 0x0400003B RID: 59
		public static ENetPeer proxyPeer;

		// Token: 0x0400003C RID: 60
		public bool mayContinue;

		// Token: 0x0400003D RID: 61
		public bool srvRunning;

		// Token: 0x0400003E RID: 62
		public bool clientRunning;

		// Token: 0x0400003F RID: 63
		public static int Growtopia_Port = 17126;

		// Token: 0x04000040 RID: 64
		public static string Growtopia_IP = "209.59.191.76";

		// Token: 0x04000041 RID: 65
		public static bool isSwitchingServer = false;

		// Token: 0x04000042 RID: 66
		public static bool blockEnterGame = false;

		// Token: 0x04000043 RID: 67
		public static string tankIDName = "";

		// Token: 0x04000044 RID: 68
		public static string tankIDPass = "";

		// Token: 0x04000045 RID: 69
		public static string game_version = "3.32";

		// Token: 0x04000046 RID: 70
		public static string country = "de";

		// Token: 0x04000047 RID: 71
		public static string requestedName = "";

		// Token: 0x04000048 RID: 72
		public static int token = 0;

		// Token: 0x04000049 RID: 73
		public static bool resetStuffNextLogon = false;

		// Token: 0x0400004A RID: 74
		public static int userID = 0;

		// Token: 0x0400004B RID: 75
		public static int lmode = 0;

		// Token: 0x0400004C RID: 76
		public static byte[] skinColor = new byte[4];

		// Token: 0x0400004D RID: 77
		public static bool hasLogonAlready = false;

		// Token: 0x0400004E RID: 78
		public static bool hasUpdatedItemsAlready = false;

		// Token: 0x0400004F RID: 79
		public static bool bypassAAP = false;

		// Token: 0x04000050 RID: 80
		public static bool ghostSkin = false;

		// Token: 0x04000051 RID: 81
		public static bool cheat_magplant = false;

		// Token: 0x04000052 RID: 82
		public static bool cheat_rgbSkin = false;

		// Token: 0x04000053 RID: 83
		public static bool cheat_autoworldban_mod = false;

		// Token: 0x04000054 RID: 84
		public static bool cheat_speedy = false;

		// Token: 0x04000055 RID: 85
		public static string macc = "00:05:01:20:30:05";

		// Token: 0x04000056 RID: 86
		public static string doorid = "";

		// Token: 0x04000057 RID: 87
		private ItemDatabase itemDB = new ItemDatabase();

		// Token: 0x04000058 RID: 88
		public static HandleMessages messageHandler = new HandleMessages();

		// Token: 0x02000005 RID: 5
		// (Invoke) Token: 0x06000047 RID: 71
		private delegate void SafeCallDelegate(string text);
	}
}
