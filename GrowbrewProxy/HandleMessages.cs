using System;
using System.Text;
using ENet.Managed;

namespace GrowbrewProxy
{
	// Token: 0x02000008 RID: 8
	public class HandleMessages
	{
		// Token: 0x0600004E RID: 78 RVA: 0x000023A3 File Offset: 0x000005A3
		private int checkPeerUsability(ENetPeer peer)
		{
			if (peer == null)
			{
				return -1;
			}
			if (peer.Data == null)
			{
				return -2;
			}
			if ((int)peer.State != 5)
			{
				return -3;
			}
			return 0;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002050 File Offset: 0x00000250
		private void LogDebugFile(string text)
		{
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00006ED8 File Offset: 0x000050D8
		private NetTypes.NetMessages GetMessageType(byte[] data)
		{
			uint result = 4294967294U;
			if (data.Length > 4)
			{
				result = BitConverter.ToUInt32(data, 0);
			}
			return (NetTypes.NetMessages)result;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000023C2 File Offset: 0x000005C2
		private NetTypes.PacketTypes GetPacketType(byte[] packetData)
		{
			return (NetTypes.PacketTypes)packetData[0];
		}
        internal static uint ComputeStringHash(string s)
        {
            uint num = 0;
            if (s != null)
            {
                num = 2166136261U;
                for (int i = 0; i < s.Length; i++)
                {
                    num = ((uint)s[i] ^ num) * 16777619U;
                }
            }
            return num;
        }
        // Token: 0x06000052 RID: 82 RVA: 0x00006EF8 File Offset: 0x000050F8
        private void OperateVariant(VariantList.VarList vList)
		{
			string text = vList.FunctionName;
			uint num = ComputeStringHash(text);
			if (num <= 1007244988U)
			{
				if (num != 375413697U)
				{
					if (num != 796027993U)
					{
						if (num != 1007244988U)
						{
							return;
						}
						if (!(text == "OnZoomCamera"))
						{
							return;
						}
						MainForm.LogText = string.Concat(new object[]
						{
							MainForm.LogText,
							"[",
							DateTime.UtcNow,
							"] (SERVER): Camera zoom parameters (",
							vList.functionArgs.Length,
							"): v1: ",
							((float)vList.functionArgs[1] / 1000f).ToString(),
							" v2: ",
							vList.functionArgs[2].ToString()
						});
						return;
					}
					else
					{
						if (!(text == "onShowCaptcha"))
						{
							return;
						}
						((string)vList.functionArgs[1]).Replace("PROCESS_LOGON_PACKET_TEXT_42", "");
						try
						{
							foreach (string text2 in ((string)vList.functionArgs[1]).Split(new char[]
							{
								'\n'
							}))
							{
								if (text2.Contains("+"))
								{
									string[] array2 = text2.Replace(" ", "").Split(new char[]
									{
										'|'
									})[1].Split(new char[]
									{
										'+'
									});
									int num2 = int.Parse(array2[0]);
									int num3 = int.Parse(array2[1]);
									string str = "action|dialog_return\ndialog_name|captcha_submit\ncaptcha_answer|" + (num2 + num3).ToString() + "\n";
									PacketSending.SendPacket(2, str, MainForm.realPeer, (ENetPacketFlags)1);
								}
							}
							return;
						}
						catch
						{
							return;
						}
					}
				}
				else if (!(text == "OnDialogRequest"))
				{
					return;
				}
				if (!((string)vList.functionArgs[1]).ToLower().Contains("captcha"))
				{
					return;
				}
				((string)vList.functionArgs[1]).Replace("PROCESS_LOGON_PACKET_TEXT_42", "");
				try
				{
					foreach (string text3 in ((string)vList.functionArgs[1]).Split(new char[]
					{
						'\n'
					}))
					{
						if (text3.Contains("+"))
						{
							string[] array3 = text3.Replace(" ", "").Split(new char[]
							{
								'|'
							})[1].Split(new char[]
							{
								'+'
							});
							int num4 = int.Parse(array3[0]);
							int num5 = int.Parse(array3[1]);
							string str2 = "action|dialog_return\ndialog_name|captcha_submit\ncaptcha_answer|" + (num4 + num5).ToString() + "\n";
							PacketSending.SendPacket(2, str2, MainForm.realPeer, (ENetPacketFlags)1);
						}
					}
					return;
				}
				catch
				{
					return;
				}
			}
			else if (num <= 1729269698U)
			{
				if (num != 1143208288U)
				{
					if (num != 1729269698U)
					{
						return;
					}
					if (!(text == "OnSuperMainStartAcceptLogonHrdxs47254722215a"))
					{
						return;
					}
					if (MainForm.skipCache)
					{
						MainForm.LogText = string.Concat(new object[]
						{
							MainForm.LogText,
							"[",
							DateTime.UtcNow,
							"] (CLIENT): Skipping potential caching (will make world list disappear)..."
						});
						GamePacketProton gamePacketProton = new GamePacketProton();
						gamePacketProton.AppendString("OnRequestWorldSelectMenu");
						PacketSending.SendData(gamePacketProton.GetBytes(), MainForm.proxyPeer, (ENetPacketFlags)1);
						return;
					}
					return;
				}
				else if (!(text == "OnSendToServer"))
				{
					return;
				}
			}
			else if (num != 2190745688U)
			{
				if (num != 2735284671U)
				{
					return;
				}
				if (!(text == "OnSpawn"))
				{
					return;
				}
				this.worldMap.playerCount++;
				string text4 = (string)vList.functionArgs[1];
				text4.Split(new char[]
				{
					'|'
				});
				Player player = new Player();
				string[] array = text4.Split(new char[]
				{
					'\n'
				});
				for (int i = 0; i < array.Length; i++)
				{
					string[] array4 = array[i].Split(new char[]
					{
						'|'
					});
					if (array4.Length == 2)
					{
						text = array4[0];
						num = ComputeStringHash(text);
						if (num <= 838441535U)
						{
							if (num != 113949757U)
							{
								if (num != 121650053U)
								{
									if (num == 838441535U)
									{
										if (text == "userID")
										{
											player.userID = Convert.ToInt32(array4[1]);
										}
									}
								}
								else if (text == "netID")
								{
									player.netID = Convert.ToInt32(array4[1]);
								}
							}
							else if (text == "mstate")
							{
								player.mstate = Convert.ToInt32(array4[1]);
							}
						}
						else if (num <= 2369371622U)
						{
							if (num != 1495980496U)
							{
								if (num == 2369371622U)
								{
									if (text == "name")
									{
										player.name = array4[1];
									}
								}
							}
							else if (text == "invis")
							{
								player.invis = Convert.ToInt32(array4[1]);
							}
						}
						else if (num != 2777748945U)
						{
							if (num == 4256694302U)
							{
								if (text == "smstate")
								{
									player.mstate = Convert.ToInt32(array4[1]);
								}
							}
						}
						else if (text == "country")
						{
							player.country = array4[1];
						}
					}
				}
				this.worldMap.players.Add(player);
				if (player.name.Length > 2)
				{
					this.worldMap.AddPlayerControlToBox(player);
				}
				if (player.name.Contains(MainForm.tankIDName))
				{
					MainForm.LogText = string.Concat(new object[]
					{
						MainForm.LogText,
						"[",
						DateTime.UtcNow,
						"] (PROXY): World player objects loaded! Your NetID:  ",
						player.netID,
						" -- Your UserID: ",
						player.userID,
						"\n"
					});
					this.worldMap.netID = player.netID;
					this.worldMap.userID = player.userID;
				}
				if (player.mstate > 0 || player.smstate > 0 || player.invis > 0)
				{
					if (MainForm.cheat_autoworldban_mod)
					{
						this.banEveryoneInWorld();
					}
					MainForm.LogText = string.Concat(new object[]
					{
						MainForm.LogText,
						"[",
						DateTime.UtcNow,
						"] (PROXY): A moderator or developer seems to have joined your world!\n"
					});
					return;
				}
				return;
			}
			else
			{
				if (!(text == "OnRemove"))
				{
					return;
				}
				string[] array5 = ((string)vList.functionArgs[1]).Split(new char[]
				{
					'|'
				});
				if (!(array5[0] != "netID"))
				{
					int num6 = -1;
					int.TryParse(array5[1], out num6);
					for (int j = 0; j < this.worldMap.players.Count; j++)
					{
						if (this.worldMap.players[j].netID == num6)
						{
							this.worldMap.players.RemoveAt(j);
							break;
						}
					}
					this.worldMap.RemovePlayerControl(num6);
					return;
				}
				return;
			}
			string text5 = (string)vList.functionArgs[4];
			int num7 = (int)vList.functionArgs[1];
			int num8 = (int)vList.functionArgs[3];
			int num9 = (int)vList.functionArgs[2];
			int num10 = (int)vList.functionArgs[5];
			MainForm.lmode = num10;
			if (MainForm.token == 0)
			{
				MainForm.token = num9;
			}
			MainForm.userID = num8;
			MainForm.LogText = string.Concat(new object[]
			{
				MainForm.LogText,
				"[",
				DateTime.UtcNow,
				"] (SERVER): OnSendToServer (func call used for server switching/sub-servers) IP: ",
				text5,
				" PORT: ",
				num7,
				" UserId: ",
				num8,
				" Session-Token: ",
				num9,
				"\n"
			});
			GamePacketProton gamePacketProton2 = new GamePacketProton();
			gamePacketProton2.AppendString("OnConsoleMessage");
			gamePacketProton2.AppendString("`6(PROXY)`o Switching subserver...``");
			PacketSending.SendData(gamePacketProton2.GetBytes(), MainForm.proxyPeer, (ENetPacketFlags)1);
			GamePacketProton gamePacketProton3 = new GamePacketProton();
			gamePacketProton3.AppendString("OnSendToServer");
			gamePacketProton3.AppendInt(2);
			gamePacketProton3.AppendInt(num9);
			gamePacketProton3.AppendInt(num8);
			gamePacketProton3.AppendString("127.0.0.1|" + MainForm.doorid);
			gamePacketProton3.AppendInt(num10);
			MainForm.doorid = "";
			PacketSending.SendData(gamePacketProton3.GetBytes(), MainForm.proxyPeer, (ENetPacketFlags)1);
			MainForm.Growtopia_IP = text5;
			MainForm.Growtopia_Port = num7;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000077DC File Offset: 0x000059DC
		private string GetProperGenericText(byte[] data)
		{
			string result = string.Empty;
			if (data.Length > 5)
			{
				int num = data.Length - 5;
				byte[] array = new byte[num];
				Array.Copy(data, 4, array, 0, num);
				result = Encoding.ASCII.GetString(array);
			}
			return result;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000023C7 File Offset: 0x000005C7
		private void SwitchServers(string ip, int port, int lmode = 0, int userid = 0, int token = 0)
		{
			MainForm.Growtopia_IP = ip;
			MainForm.Growtopia_Port = port;
			this.isSwitchingServers = true;
			MainForm.ConnectToServer();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000781C File Offset: 0x00005A1C
		private void banEveryoneInWorld()
		{
			foreach (Player player in this.worldMap.players)
			{
				string text = player.name.Substring(2);
				text = text.Substring(0, text.Length - 2);
				PacketSending.SendPacket(2, "action|input\n|text|/ban " + text, MainForm.realPeer, (ENetPacketFlags)1);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000078A0 File Offset: 0x00005AA0
		public string HandlePacketFromClient(ENetPacket packet)
		{
			if (MainForm.proxyPeer == null)
			{
				return "";
			}
			if ((int)MainForm.proxyPeer.State != 5)
			{
				return "";
			}
			if (MainForm.realPeer == null)
			{
				return "";
			}
			if ((int)MainForm.realPeer.State != 5)
			{
				return "";
			}
			byte[] payloadFinal = packet.GetPayloadFinal();
			switch (this.GetMessageType(payloadFinal))
			{
			case NetTypes.NetMessages.GENERIC_TEXT:
			{
				string properGenericText = this.GetProperGenericText(payloadFinal);
				MainForm.LogText = string.Concat(new object[]
				{
					MainForm.LogText,
					"[",
					DateTime.UtcNow,
					"] (CLIENT): String package fetched:\n",
					properGenericText,
					"\n"
				});
				if (!properGenericText.StartsWith("action|"))
				{
					for (int i = 0; i < 1000; i++)
					{
						PacketSending.SendPacket(2, "action|refresh_item_data\n", MainForm.realPeer, (ENetPacketFlags)1);
					}
					string[] array = properGenericText.Split(new char[]
					{
						'\n'
					});
					for (int j = 0; j < array.Length; j++)
					{
						string[] array2 = array[j].Split(new char[]
						{
							'|'
						});
						if (array2.Length == 2)
						{
							string a = array2[0];
							if (!(a == "tankIDName"))
							{
								if (!(a == "tankIDPass"))
								{
									if (a == "requestedName")
									{
										MainForm.requestedName = array2[1];
									}
								}
								else
								{
									MainForm.tankIDPass = array2[1];
								}
							}
							else
							{
								MainForm.LogText = string.Concat(new object[]
								{
									MainForm.LogText,
									"[",
									DateTime.UtcNow,
									"] (PROXY): Account name is: ",
									array2[1],
									"\n"
								});
								MainForm.tankIDName = array2[1];
							}
						}
					}
					bool hasGrowId = false;
					if (MainForm.tankIDName.Length > 0)
					{
						hasGrowId = true;
					}
					PacketSending.SendPacket(2, MainForm.CreateLogonPacket(hasGrowId), MainForm.realPeer, (ENetPacketFlags)1);
					return "Sent logon packet!";
				}
				string text = properGenericText.Substring(7, properGenericText.Length - 7);
				string text2 = "input\n|text|";
				if (text.StartsWith("enter_game"))
				{
					if (MainForm.blockEnterGame)
					{
						return "Blocked enter_game packet!";
					}
					this.enteredGame = true;
				}
				else if (text.StartsWith(text2))
				{
					string text3 = text.Substring(text2.Length);
					if (text3.Length > 0 && text3.StartsWith("/") && text3 == "/banworld")
					{
						this.banEveryoneInWorld();
						return "called /banworld, attempting to ban everyone who is in world (requires admin/owner)";
					}
				}
				break;
			}
			case NetTypes.NetMessages.GAME_MESSAGE:
			{
				string properGenericText2 = this.GetProperGenericText(payloadFinal);
				MainForm.LogText = string.Concat(new object[]
				{
					MainForm.LogText,
					"[",
					DateTime.UtcNow,
					"] (CLIENT): String package fetched:\n",
					properGenericText2,
					"\n"
				});
				if (properGenericText2.StartsWith("action|") && properGenericText2.Substring(7, properGenericText2.Length - 7) == "quit")
				{
					MainForm.realPeer.DisconnectLater(100U);
					MainForm.proxyPeer.DisconnectLater(100U);
				}
				break;
			}
			case NetTypes.NetMessages.GAME_PACKET:
			{
				TankPacket tankPacket = TankPacket.UnpackFromPacket(payloadFinal);
				NetTypes.PacketTypes packetTypes = (NetTypes.PacketTypes)((byte)tankPacket.PacketType);
				if (packetTypes != NetTypes.PacketTypes.PLAYER_LOGIC_UPDATE)
				{
					if (packetTypes != NetTypes.PacketTypes.ITEM_ACTIVATE_OBJ)
					{
						if (packetTypes == NetTypes.PacketTypes.APP_INTEGRITY_FAIL)
						{
							return "Possible autoban packet with id (25) from your GT Client has been blocked.";
						}
					}
					else
					{
						this.worldMap.dropped_ITEMUID = tankPacket.MainValue;
					}
				}
				else
				{
					if (tankPacket.PunchX > 0 || tankPacket.PunchY > 0)
					{
						MainForm.LogText = string.Concat(new object[]
						{
							MainForm.LogText,
							"[",
							DateTime.UtcNow,
							"] (PROXY): PunchX/PunchY detected, pX: ",
							tankPacket.PunchX.ToString(),
							" pY: ",
							tankPacket.PunchY.ToString(),
							"\n"
						});
					}
					this.worldMap.player.X = (int)tankPacket.X;
					this.worldMap.player.Y = (int)tankPacket.Y;
				}
				break;
			}
			case NetTypes.NetMessages.TRACK:
				return "Packet with messagetype used for tracking was blocked!";
			case NetTypes.NetMessages.LOG_REQ:
				return "Log request packet from client was blocked!";
			}
			PacketSending.SendData(payloadFinal, MainForm.realPeer, (ENetPacketFlags)1);
			return string.Empty;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00007CE4 File Offset: 0x00005EE4
		private void SpoofedPingReply()
		{
			if (this.worldMap == null)
			{
				return;
			}
			PacketSending.SendPacketRaw(4, new TankPacket
			{
				YSpeed = 1000f,
				XSpeed = 250f,
				X = (float)this.worldMap.player.X,
				Y = (float)this.worldMap.player.Y,
				NetID = this.worldMap.player.netID,
				Padding = 64f
			}.PackForSendingRaw(), MainForm.realPeer, (ENetPacketFlags)1);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00007D78 File Offset: 0x00005F78
		public string HandlePacketFromServer(ENetPacket packet)
		{
			if (MainForm.proxyPeer == null)
			{
				return "";
			}
			if ((int)MainForm.proxyPeer.State != 5)
			{
				return "";
			}
			if (MainForm.realPeer == null)
			{
				return "";
			}
			if ((int)MainForm.realPeer.State != 5)
			{
				return "";
			}
			byte[] payloadFinal = packet.GetPayloadFinal();
			NetTypes.NetMessages messageType = this.GetMessageType(payloadFinal);
			switch (messageType)
			{
			case NetTypes.NetMessages.SERVER_HELLO:
				MainForm.LogText = string.Concat(new object[]
				{
					MainForm.LogText,
					"[",
					DateTime.UtcNow,
					"] (SERVER): Initial logon accepted.\n"
				});
				goto IL_30B;
			case NetTypes.NetMessages.GAME_MESSAGE:
				MainForm.LogText = string.Concat(new object[]
				{
					MainForm.LogText,
					"[",
					DateTime.UtcNow,
					"] (SERVER): A game_msg packet was sent.\n"
				});
				if (this.GetProperGenericText(payloadFinal).Contains("Server requesting that you re-logon..."))
				{
					goto IL_30B;
				}
				goto IL_30B;
			case NetTypes.NetMessages.GAME_PACKET:
			{
				byte[] array = VariantList.get_struct_data(payloadFinal);
				if (array == null)
				{
					goto IL_30B;
				}
				NetTypes.PacketTypes packetType = this.GetPacketType(array);
				if (packetType <= NetTypes.PacketTypes.LOAD_MAP)
				{
					if (packetType != NetTypes.PacketTypes.CALL_FUNCTION)
					{
						if (packetType != NetTypes.PacketTypes.LOAD_MAP)
						{
							goto IL_30B;
						}
						if (MainForm.LogText.Length >= 65536)
						{
							MainForm.LogText = string.Empty;
						}
						this.worldMap.Dispose();
						this.worldMap = this.worldMap.LoadMap(array);
						goto IL_30B;
					}
					else
					{
						VariantList.VarList call = VariantList.GetCall(VariantList.get_extended_data(array));
						this.OperateVariant(call);
						if (call.FunctionName == "OnSendToServer")
						{
							return "Server switching forced, not continuing as Proxy Client has to deal with this.";
						}
						goto IL_30B;
					}
				}
				else if (packetType != NetTypes.PacketTypes.MODIFY_ITEM_OBJ)
				{
					if (packetType == NetTypes.PacketTypes.APPLY_LOCK)
					{
						goto IL_30B;
					}
					if (packetType != NetTypes.PacketTypes.PING_REQ)
					{
						goto IL_30B;
					}
					this.SpoofedPingReply();
					goto IL_30B;
				}
				else
				{
					TankPacket tankPacket = TankPacket.UnpackFromPacket(payloadFinal);
					if (tankPacket.NetID != -1)
					{
						goto IL_30B;
					}
					if (this.worldMap == null)
					{
						MainForm.LogText = string.Concat(new object[]
						{
							MainForm.LogText,
							"[",
							DateTime.UtcNow,
							"] (PROXY): (ERROR) World map was null.\n"
						});
						goto IL_30B;
					}
					this.worldMap.dropped_ITEMUID++;
					DroppedObject droppedObject = default(DroppedObject);
					droppedObject.id = tankPacket.MainValue;
					droppedObject.itemCount = payloadFinal[16];
					droppedObject.x = tankPacket.X;
					droppedObject.y = tankPacket.Y;
					droppedObject.uid = this.worldMap.dropped_ITEMUID;
					this.worldMap.droppedItems.Add(droppedObject);
					if (MainForm.cheat_magplant)
					{
						PacketSending.SendPacketRaw(4, new TankPacket
						{
							PacketType = 11,
							NetID = tankPacket.NetID,
							X = (float)((int)tankPacket.X),
							Y = (float)((int)tankPacket.Y),
							MainValue = droppedObject.uid
						}.PackForSendingRaw(), MainForm.realPeer, (ENetPacketFlags)1);
						goto IL_30B;
					}
					goto IL_30B;
				}
				break;
			}
			case NetTypes.NetMessages.ERROR:
			case NetTypes.NetMessages.TRACK:
			case NetTypes.NetMessages.LOG_REQ:
				goto IL_30B;
			}
			return "(SERVER): An unknown event occured. Message Type: " + messageType.ToString() + "\n";
			IL_30B:
			PacketSending.SendData(payloadFinal, MainForm.proxyPeer, (ENetPacketFlags)1);
			return string.Empty;
		}

		// Token: 0x040000B0 RID: 176
		private VariantList variant = new VariantList();

		// Token: 0x040000B1 RID: 177
		public World worldMap = new World();

		// Token: 0x040000B2 RID: 178
		private bool isSwitchingServers;

		// Token: 0x040000B3 RID: 179
		public bool enteredGame;

		// Token: 0x040000B4 RID: 180
		public bool serverRelogReq;

		// Token: 0x02000009 RID: 9
		// (Invoke) Token: 0x0600005B RID: 91
		private delegate void SafeCallDelegate(string text);
	}
}
