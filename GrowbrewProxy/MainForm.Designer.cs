namespace GrowbrewProxy
{
	// Token: 0x02000004 RID: 4
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00002352 File Offset: 0x00000552
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003D88 File Offset: 0x00001F88
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GrowbrewProxy.MainForm));
			this.runproxy = new global::System.Windows.Forms.Button();
			this.statuslabel = new global::System.Windows.Forms.Label();
			this.labelsrvrunning = new global::System.Windows.Forms.Label();
			this.labelclientrunning = new global::System.Windows.Forms.Label();
			this.logBox = new global::System.Windows.Forms.RichTextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.formTabs = new global::System.Windows.Forms.TabControl();
			this.proxyPage = new global::System.Windows.Forms.TabPage();
           
			this.label13 = new global::System.Windows.Forms.Label();
			this.button11 = new global::System.Windows.Forms.Button();
			this.label12 = new global::System.Windows.Forms.Label();
			this.portBox = new global::System.Windows.Forms.NumericUpDown();
			this.button2 = new global::System.Windows.Forms.Button();
			this.updateAddress = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.ipaddrBox = new global::System.Windows.Forms.TextBox();
			this.cheatPage = new global::System.Windows.Forms.TabPage();
			this.cheattabs = new global::System.Windows.Forms.TabControl();
			this.internalcheattab = new global::System.Windows.Forms.TabPage();
			this.label15 = new global::System.Windows.Forms.Label();
			this.checkBox6 = new global::System.Windows.Forms.CheckBox();
			this.button10 = new global::System.Windows.Forms.Button();
			this.button9 = new global::System.Windows.Forms.Button();
			this.button8 = new global::System.Windows.Forms.Button();
			this.button7 = new global::System.Windows.Forms.Button();
			this.checkBox5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.button6 = new global::System.Windows.Forms.Button();
			this.button5 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.send2client = new global::System.Windows.Forms.CheckBox();
			this.packetText = new global::System.Windows.Forms.RichTextBox();
			this.sendgameact = new global::System.Windows.Forms.Button();
			this.sendtextact = new global::System.Windows.Forms.Button();
			this.ghostmodskin = new global::System.Windows.Forms.CheckBox();
			this.actionButtonClicked = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.nameBoxOn = new global::System.Windows.Forms.TextBox();
			this.punishview = new global::System.Windows.Forms.Button();
			this.cheat_speed = new global::System.Windows.Forms.CheckBox();
			this.posXYLabel = new global::System.Windows.Forms.Label();
			this.hack_autoworldbanmod = new global::System.Windows.Forms.CheckBox();
			this.playerMgr = new global::System.Windows.Forms.Button();
			this.hack_magplant = new global::System.Windows.Forms.CheckBox();
			this.chnamelabel = new global::System.Windows.Forms.Label();
			this.rgbSkinHack = new global::System.Windows.Forms.CheckBox();
			this.changeNameBox = new global::System.Windows.Forms.TextBox();
			this.externalcheattab = new global::System.Windows.Forms.TabPage();
			this.showExternalsbtn = new global::System.Windows.Forms.Button();
			this.explanatoryLabel = new global::System.Windows.Forms.LinkLabel();
			this.internalextrapage = new global::System.Windows.Forms.TabPage();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.button3 = new global::System.Windows.Forms.Button();
			this.label11 = new global::System.Windows.Forms.Label();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.itemid = new global::System.Windows.Forms.TextBox();
			this.tileY = new global::System.Windows.Forms.TextBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.tileX = new global::System.Windows.Forms.TextBox();
			this.macUpdate = new global::System.Windows.Forms.Button();
			this.label7 = new global::System.Windows.Forms.Label();
			this.setMac = new global::System.Windows.Forms.TextBox();
			this.custom_collect_y = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.custom_collect_x = new global::System.Windows.Forms.TextBox();
			this.expllabel = new global::System.Windows.Forms.Label();
			this.custom_collect_uid = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.extraPage = new global::System.Windows.Forms.TabPage();
			this.reloadLogs = new global::System.Windows.Forms.Button();
			this.entireLog = new global::System.Windows.Forms.RichTextBox();
			this.aboutlabel = new global::System.Windows.Forms.LinkLabel();
			this.vLabel = new global::System.Windows.Forms.Label();
			this.playerLogicUpdate = new global::System.Windows.Forms.Timer(this.components);
			this.label14 = new global::System.Windows.Forms.Label();
			this.textBox2 = new global::System.Windows.Forms.TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.button12 = new global::System.Windows.Forms.Button();
			this.formTabs.SuspendLayout();
			this.proxyPage.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.portBox).BeginInit();
			this.cheatPage.SuspendLayout();
			this.cheattabs.SuspendLayout();
			this.internalcheattab.SuspendLayout();
			this.externalcheattab.SuspendLayout();
			this.internalextrapage.SuspendLayout();
			this.extraPage.SuspendLayout();
			base.SuspendLayout();
			this.runproxy.Location = new global::System.Drawing.Point(166, 168);
			this.runproxy.Name = "runproxy";
			this.runproxy.Size = new global::System.Drawing.Size(177, 54);
			this.runproxy.TabIndex = 0;
			this.runproxy.Text = "Start the proxy!";
			this.runproxy.UseVisualStyleBackColor = true;
			this.runproxy.Click += new global::System.EventHandler(this.runproxy_Click);
			this.statuslabel.AutoSize = true;
			this.statuslabel.Location = new global::System.Drawing.Point(6, 3);
			this.statuslabel.Name = "statuslabel";
			this.statuslabel.Size = new global::System.Drawing.Size(40, 13);
			this.statuslabel.TabIndex = 1;
			this.statuslabel.Text = "Status:";
			this.labelsrvrunning.AutoSize = true;
			this.labelsrvrunning.ForeColor = global::System.Drawing.Color.FromArgb(255, 128, 0);
			this.labelsrvrunning.Location = new global::System.Drawing.Point(6, 24);
			this.labelsrvrunning.Name = "labelsrvrunning";
			this.labelsrvrunning.Size = new global::System.Drawing.Size(107, 13);
			this.labelsrvrunning.TabIndex = 2;
			this.labelsrvrunning.Text = "Server is not running!";
			this.labelclientrunning.AutoSize = true;
			this.labelclientrunning.ForeColor = global::System.Drawing.Color.FromArgb(255, 128, 0);
			this.labelclientrunning.Location = new global::System.Drawing.Point(6, 37);
			this.labelclientrunning.Name = "labelclientrunning";
			this.labelclientrunning.Size = new global::System.Drawing.Size(102, 13);
			this.labelclientrunning.TabIndex = 3;
			this.labelclientrunning.Text = "Client is not running!";
			this.logBox.Location = new global::System.Drawing.Point(152, 16);
			this.logBox.Name = "logBox";
			this.logBox.Size = new global::System.Drawing.Size(351, 135);
			this.logBox.TabIndex = 4;
			this.logBox.Text = "";
			this.logBox.TextChanged += new global::System.EventHandler(this.logBox_TextChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(149, 3);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(49, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Log Box:";
			this.formTabs.Controls.Add(this.proxyPage);
			this.formTabs.Controls.Add(this.cheatPage);
			this.formTabs.Controls.Add(this.extraPage);
			this.formTabs.Location = new global::System.Drawing.Point(-1, 0);
			this.formTabs.Name = "formTabs";
			this.formTabs.SelectedIndex = 0;
			this.formTabs.Size = new global::System.Drawing.Size(519, 252);
			this.formTabs.TabIndex = 6;
			this.formTabs.SelectedIndexChanged += new global::System.EventHandler(this.formTabs_SelectedIndexChanged);
			this.proxyPage.Controls.Add(this.label13);
			this.proxyPage.Controls.Add(this.button11);
			this.proxyPage.Controls.Add(this.label12);
			this.proxyPage.Controls.Add(this.portBox);
			this.proxyPage.Controls.Add(this.button2);
			this.proxyPage.Controls.Add(this.updateAddress);
			this.proxyPage.Controls.Add(this.label3);
			this.proxyPage.Controls.Add(this.label2);
			this.proxyPage.Controls.Add(this.ipaddrBox);
			this.proxyPage.Controls.Add(this.labelclientrunning);
			this.proxyPage.Controls.Add(this.logBox);
			this.proxyPage.Controls.Add(this.label1);
			this.proxyPage.Controls.Add(this.labelsrvrunning);
			this.proxyPage.Controls.Add(this.statuslabel);
			this.proxyPage.Controls.Add(this.runproxy);
			this.proxyPage.Location = new global::System.Drawing.Point(4, 22);
			this.proxyPage.Name = "proxyPage";
			this.proxyPage.Padding = new global::System.Windows.Forms.Padding(3);
			this.proxyPage.Size = new global::System.Drawing.Size(511, 226);
			this.proxyPage.TabIndex = 0;
			this.proxyPage.Text = "Proxy";
			this.proxyPage.UseVisualStyleBackColor = true;
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(7, 54);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(121, 13);
			this.label13.TabIndex = 15;
			this.label13.Text = "HTTP-Server is running!";
			this.label13.Visible = false;
			this.button11.Location = new global::System.Drawing.Point(12, 83);
			this.button11.Name = "button11";
			this.button11.Size = new global::System.Drawing.Size(121, 23);
			this.button11.TabIndex = 14;
			this.button11.Text = "Start HTTP Server";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new global::System.EventHandler(this.button11_Click);
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(163, 154);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(288, 13);
			this.label12.TabIndex = 13;
			this.label12.Text = "if you are stuck at server request logon, click update ip/port";
			this.portBox.Location = new global::System.Drawing.Point(13, 199);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.portBox;
			int[] array = new int[4];
			array[0] = 65535;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.portBox;
			int[] array2 = new int[4];
			array2[0] = 1;
			numericUpDown2.Minimum = new decimal(array2);
			this.portBox.Name = "portBox";
			this.portBox.Size = new global::System.Drawing.Size(81, 20);
			this.portBox.TabIndex = 12;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.portBox;
			int[] array3 = new int[4];
			array3[0] = 17126;
			numericUpDown3.Value = new decimal(array3);
			this.button2.Location = new global::System.Drawing.Point(370, 196);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(133, 23);
			this.button2.TabIndex = 11;
			this.button2.Text = "Force Disconnect Client";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.updateAddress.Location = new global::System.Drawing.Point(12, 112);
			this.updateAddress.Name = "updateAddress";
			this.updateAddress.Size = new global::System.Drawing.Size(101, 23);
			this.updateAddress.TabIndex = 10;
			this.updateAddress.Text = "Update IP/Port";
			this.updateAddress.UseVisualStyleBackColor = true;
			this.updateAddress.Click += new global::System.EventHandler(this.button1_Click_1);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(9, 183);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(29, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Port:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(10, 138);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(20, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "IP:";
			this.ipaddrBox.Location = new global::System.Drawing.Point(13, 154);
			this.ipaddrBox.Name = "ipaddrBox";
			this.ipaddrBox.Size = new global::System.Drawing.Size(100, 20);
			this.ipaddrBox.TabIndex = 6;
			this.ipaddrBox.Text = "209.59.191.76";
			this.cheatPage.Controls.Add(this.cheattabs);
			this.cheatPage.Location = new global::System.Drawing.Point(4, 22);
			this.cheatPage.Name = "cheatPage";
			this.cheatPage.Padding = new global::System.Windows.Forms.Padding(3);
			this.cheatPage.Size = new global::System.Drawing.Size(511, 226);
			this.cheatPage.TabIndex = 1;
			this.cheatPage.Text = "Cheats/Mods/Misc";
			this.cheatPage.UseVisualStyleBackColor = true;
			this.cheattabs.Controls.Add(this.internalcheattab);
			this.cheattabs.Controls.Add(this.externalcheattab);
			this.cheattabs.Controls.Add(this.internalextrapage);
			this.cheattabs.Location = new global::System.Drawing.Point(0, 0);
			this.cheattabs.Name = "cheattabs";
			this.cheattabs.SelectedIndex = 0;
			this.cheattabs.Size = new global::System.Drawing.Size(508, 226);
			this.cheattabs.TabIndex = 5;
			this.internalcheattab.Controls.Add(this.label15);
			this.internalcheattab.Controls.Add(this.checkBox6);
			this.internalcheattab.Controls.Add(this.button10);
			this.internalcheattab.Controls.Add(this.button9);
			this.internalcheattab.Controls.Add(this.button8);
			this.internalcheattab.Controls.Add(this.button7);
			this.internalcheattab.Controls.Add(this.checkBox5);
			this.internalcheattab.Controls.Add(this.checkBox4);
			this.internalcheattab.Controls.Add(this.checkBox3);
			this.internalcheattab.Controls.Add(this.checkBox2);
			this.internalcheattab.Controls.Add(this.button6);
			this.internalcheattab.Controls.Add(this.button5);
			this.internalcheattab.Controls.Add(this.button4);
			this.internalcheattab.Controls.Add(this.send2client);
			this.internalcheattab.Controls.Add(this.packetText);
			this.internalcheattab.Controls.Add(this.sendgameact);
			this.internalcheattab.Controls.Add(this.sendtextact);
			this.internalcheattab.Controls.Add(this.ghostmodskin);
			this.internalcheattab.Controls.Add(this.actionButtonClicked);
			this.internalcheattab.Controls.Add(this.label6);
			this.internalcheattab.Controls.Add(this.nameBoxOn);
			this.internalcheattab.Controls.Add(this.punishview);
			this.internalcheattab.Controls.Add(this.cheat_speed);
			this.internalcheattab.Controls.Add(this.posXYLabel);
			this.internalcheattab.Controls.Add(this.hack_autoworldbanmod);
			this.internalcheattab.Controls.Add(this.playerMgr);
			this.internalcheattab.Controls.Add(this.hack_magplant);
			this.internalcheattab.Controls.Add(this.chnamelabel);
			this.internalcheattab.Controls.Add(this.rgbSkinHack);
			this.internalcheattab.Controls.Add(this.changeNameBox);
			this.internalcheattab.Location = new global::System.Drawing.Point(4, 22);
			this.internalcheattab.Name = "internalcheattab";
			this.internalcheattab.Padding = new global::System.Windows.Forms.Padding(3);
			this.internalcheattab.Size = new global::System.Drawing.Size(500, 200);
			this.internalcheattab.TabIndex = 0;
			this.internalcheattab.Text = "Internal";
			this.internalcheattab.UseVisualStyleBackColor = true;
			this.label15.AutoSize = true;
			this.label15.Location = new global::System.Drawing.Point(269, 3);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(116, 26);
			this.label15.TabIndex = 32;
			this.label15.Text = "for private servers :\r\n(some have them fixed)";
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new global::System.Drawing.Point(254, 79);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new global::System.Drawing.Size(247, 30);
			this.checkBox6.TabIndex = 31;
			this.checkBox6.Text = "instant world select menu (skip cache updates)\r\n(only use it when you updated items already)";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.CheckedChanged += new global::System.EventHandler(this.checkBox6_CheckedChanged);
			this.button10.Location = new global::System.Drawing.Point(174, 167);
			this.button10.Name = "button10";
			this.button10.Size = new global::System.Drawing.Size(59, 31);
			this.button10.TabIndex = 30;
			this.button10.Text = "Trade all";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new global::System.EventHandler(this.button10_Click);
			this.button9.Location = new global::System.Drawing.Point(109, 167);
			this.button9.Name = "button9";
			this.button9.Size = new global::System.Drawing.Size(59, 31);
			this.button9.TabIndex = 29;
			this.button9.Text = "Kick all";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new global::System.EventHandler(this.button9_Click);
			this.button8.Location = new global::System.Drawing.Point(174, 135);
			this.button8.Name = "button8";
			this.button8.Size = new global::System.Drawing.Size(59, 28);
			this.button8.TabIndex = 28;
			this.button8.Text = "Ban all";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new global::System.EventHandler(this.button8_Click);
			this.button7.Location = new global::System.Drawing.Point(109, 135);
			this.button7.Name = "button7";
			this.button7.Size = new global::System.Drawing.Size(59, 28);
			this.button7.TabIndex = 27;
			this.button7.Text = "Pull all";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new global::System.EventHandler(this.button7_Click);
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new global::System.Drawing.Point(159, 86);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new global::System.Drawing.Size(60, 17);
			this.checkBox5.TabIndex = 26;
			this.checkBox5.Text = "rayman";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new global::System.Drawing.Point(159, 69);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new global::System.Drawing.Size(108, 17);
			this.checkBox4.TabIndex = 25;
			this.checkBox4.Text = "(break below too)";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new global::System.Drawing.Point(98, 75);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new global::System.Drawing.Size(67, 17);
			this.checkBox3.TabIndex = 24;
			this.checkBox3.Text = "Nuker ->";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new global::System.EventHandler(this.checkBox3_CheckedChanged);
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new global::System.Drawing.Point(382, 65);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(111, 17);
			this.checkBox2.TabIndex = 23;
			this.checkBox2.Text = "block enter_game";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new global::System.EventHandler(this.checkBox2_CheckedChanged);
			this.button6.Location = new global::System.Drawing.Point(268, 29);
			this.button6.Name = "button6";
			this.button6.Size = new global::System.Drawing.Size(53, 23);
			this.button6.TabIndex = 22;
			this.button6.Text = "freeze1";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new global::System.EventHandler(this.button6_Click);
			this.button5.Location = new global::System.Drawing.Point(323, 52);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(53, 23);
			this.button5.TabIndex = 21;
			this.button5.Text = "crash2";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new global::System.EventHandler(this.button5_Click_1);
			this.button4.Location = new global::System.Drawing.Point(268, 52);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(53, 23);
			this.button4.TabIndex = 20;
			this.button4.Text = "crash1";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new global::System.EventHandler(this.button4_Click_1);
			this.send2client.AutoSize = true;
			this.send2client.Location = new global::System.Drawing.Point(350, 153);
			this.send2client.Name = "send2client";
			this.send2client.Size = new global::System.Drawing.Size(147, 17);
			this.send2client.TabIndex = 19;
			this.send2client.Text = "send to proxy peer (client)";
			this.send2client.UseVisualStyleBackColor = true;
			this.packetText.Location = new global::System.Drawing.Point(257, 109);
			this.packetText.Name = "packetText";
			this.packetText.Size = new global::System.Drawing.Size(237, 43);
			this.packetText.TabIndex = 18;
			this.packetText.Text = "";
			this.sendgameact.Location = new global::System.Drawing.Point(257, 170);
			this.sendgameact.Name = "sendgameact";
			this.sendgameact.Size = new global::System.Drawing.Size(119, 23);
			this.sendgameact.TabIndex = 17;
			this.sendgameact.Text = "Send game action!";
			this.sendgameact.UseVisualStyleBackColor = true;
			this.sendgameact.Click += new global::System.EventHandler(this.button5_Click);
			this.sendtextact.Location = new global::System.Drawing.Point(382, 170);
			this.sendtextact.Name = "sendtextact";
			this.sendtextact.Size = new global::System.Drawing.Size(115, 23);
			this.sendtextact.TabIndex = 16;
			this.sendtextact.Text = "Send text action!";
			this.sendtextact.UseVisualStyleBackColor = true;
			this.sendtextact.Click += new global::System.EventHandler(this.button4_Click);
			this.ghostmodskin.AutoSize = true;
			this.ghostmodskin.Location = new global::System.Drawing.Point(85, 29);
			this.ghostmodskin.Name = "ghostmodskin";
			this.ghostmodskin.Size = new global::System.Drawing.Size(79, 17);
			this.ghostmodskin.TabIndex = 15;
			this.ghostmodskin.Text = "/ghost skin";
			this.ghostmodskin.UseVisualStyleBackColor = true;
			this.ghostmodskin.CheckedChanged += new global::System.EventHandler(this.ghostmodskin_CheckedChanged);
			this.actionButtonClicked.Location = new global::System.Drawing.Point(144, 109);
			this.actionButtonClicked.Name = "actionButtonClicked";
			this.actionButtonClicked.Size = new global::System.Drawing.Size(100, 20);
			this.actionButtonClicked.TabIndex = 12;
			this.actionButtonClicked.TextChanged += new global::System.EventHandler(this.actionButtonClicked_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(6, 112);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(26, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "ON:";
			this.nameBoxOn.Location = new global::System.Drawing.Point(38, 109);
			this.nameBoxOn.Name = "nameBoxOn";
			this.nameBoxOn.Size = new global::System.Drawing.Size(100, 20);
			this.nameBoxOn.TabIndex = 10;
			this.nameBoxOn.TextChanged += new global::System.EventHandler(this.nameBoxOn_TextChanged);
			this.punishview.Location = new global::System.Drawing.Point(6, 135);
			this.punishview.Name = "punishview";
			this.punishview.Size = new global::System.Drawing.Size(102, 35);
			this.punishview.TabIndex = 9;
			this.punishview.Text = "Dialog";
			this.punishview.UseVisualStyleBackColor = true;
			this.punishview.Click += new global::System.EventHandler(this.button3_Click_1);
			this.cheat_speed.AutoSize = true;
			this.cheat_speed.Location = new global::System.Drawing.Point(6, 75);
			this.cheat_speed.Name = "cheat_speed";
			this.cheat_speed.Size = new global::System.Drawing.Size(124, 30);
			this.cheat_speed.TabIndex = 8;
			this.cheat_speed.Text = "Super speed\r\n(never gets patched)";
			this.cheat_speed.UseVisualStyleBackColor = true;
			this.cheat_speed.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			this.posXYLabel.AutoSize = true;
			this.posXYLabel.Location = new global::System.Drawing.Point(394, 50);
			this.posXYLabel.Name = "posXYLabel";
			this.posXYLabel.Size = new global::System.Drawing.Size(48, 13);
			this.posXYLabel.TabIndex = 7;
			this.posXYLabel.Text = "X: 0 Y: 0";
			this.hack_autoworldbanmod.AutoSize = true;
			this.hack_autoworldbanmod.Location = new global::System.Drawing.Point(6, 52);
			this.hack_autoworldbanmod.Name = "hack_autoworldbanmod";
			this.hack_autoworldbanmod.Size = new global::System.Drawing.Size(173, 17);
			this.hack_autoworldbanmod.TabIndex = 6;
			this.hack_autoworldbanmod.Text = "Auto world ban when mod joins";
			this.hack_autoworldbanmod.UseVisualStyleBackColor = true;
			this.hack_autoworldbanmod.CheckedChanged += new global::System.EventHandler(this.hack_autoworldbanmod_CheckedChanged);
			this.playerMgr.Location = new global::System.Drawing.Point(6, 170);
			this.playerMgr.Name = "playerMgr";
			this.playerMgr.Size = new global::System.Drawing.Size(97, 30);
			this.playerMgr.TabIndex = 5;
			this.playerMgr.Text = "Player Manager";
			this.playerMgr.UseVisualStyleBackColor = true;
			this.playerMgr.Click += new global::System.EventHandler(this.button3_Click);
			this.hack_magplant.AutoSize = true;
			this.hack_magplant.Location = new global::System.Drawing.Point(6, 6);
			this.hack_magplant.Name = "hack_magplant";
			this.hack_magplant.Size = new global::System.Drawing.Size(216, 17);
			this.hack_magplant.TabIndex = 0;
			this.hack_magplant.Text = "Magplant Hack / Pickup range 9 blocks";
			this.hack_magplant.UseVisualStyleBackColor = true;
			this.hack_magplant.CheckedChanged += new global::System.EventHandler(this.hack_magplant_CheckedChanged);
			this.chnamelabel.AutoSize = true;
			this.chnamelabel.Location = new global::System.Drawing.Point(391, 7);
			this.chnamelabel.Name = "chnamelabel";
			this.chnamelabel.Size = new global::System.Drawing.Size(80, 13);
			this.chnamelabel.TabIndex = 3;
			this.chnamelabel.Text = "Name changer:";
			this.rgbSkinHack.AutoSize = true;
			this.rgbSkinHack.Location = new global::System.Drawing.Point(6, 29);
			this.rgbSkinHack.Name = "rgbSkinHack";
			this.rgbSkinHack.Size = new global::System.Drawing.Size(73, 17);
			this.rgbSkinHack.TabIndex = 4;
			this.rgbSkinHack.Text = "RGB Skin";
			this.rgbSkinHack.UseVisualStyleBackColor = true;
			this.rgbSkinHack.CheckedChanged += new global::System.EventHandler(this.rgbSkinHack_CheckedChanged);
			this.changeNameBox.Location = new global::System.Drawing.Point(394, 23);
			this.changeNameBox.Name = "changeNameBox";
			this.changeNameBox.Size = new global::System.Drawing.Size(100, 20);
			this.changeNameBox.TabIndex = 2;
			this.changeNameBox.TextChanged += new global::System.EventHandler(this.changeNameBox_TextChanged);
			this.externalcheattab.Controls.Add(this.showExternalsbtn);
			this.externalcheattab.Controls.Add(this.explanatoryLabel);
			this.externalcheattab.Location = new global::System.Drawing.Point(4, 22);
			this.externalcheattab.Name = "externalcheattab";
			this.externalcheattab.Padding = new global::System.Windows.Forms.Padding(3);
			this.externalcheattab.Size = new global::System.Drawing.Size(500, 200);
			this.externalcheattab.TabIndex = 1;
			this.externalcheattab.Text = "External";
			this.externalcheattab.UseVisualStyleBackColor = true;
			this.showExternalsbtn.Location = new global::System.Drawing.Point(6, 114);
			this.showExternalsbtn.Name = "showExternalsbtn";
			this.showExternalsbtn.Size = new global::System.Drawing.Size(255, 28);
			this.showExternalsbtn.TabIndex = 1;
			this.showExternalsbtn.Text = "Okay, got it! Show me the external cheats now!";
			this.showExternalsbtn.UseVisualStyleBackColor = true;
			this.showExternalsbtn.Click += new global::System.EventHandler(this.showExternalsbtn_Click);
			this.explanatoryLabel.AutoSize = true;
			this.explanatoryLabel.Location = new global::System.Drawing.Point(6, 59);
			this.explanatoryLabel.Name = "explanatoryLabel";
			this.explanatoryLabel.Size = new global::System.Drawing.Size(467, 52);
			this.explanatoryLabel.TabIndex = 0;
			this.explanatoryLabel.TabStop = true;
			this.explanatoryLabel.Text = "Cheats in here usually require proper version (for now, external cheats support 3.021 only,\r\nand they require a 64bit system, wont be updating opcodes all the time so rely on the internal ones\r\nwhich work over packet sending which do not get patched for every release of new gt version.\r\nExternal cheats also usually only are made over *byte patching* in here.";

            this.internalextrapage.Controls.Add(this.button12);
			this.internalextrapage.Controls.Add(this.label16);
			this.internalextrapage.Controls.Add(this.textBox2);
			this.internalextrapage.Controls.Add(this.checkBox1);
			this.internalextrapage.Controls.Add(this.button3);
			this.internalextrapage.Controls.Add(this.label11);
			this.internalextrapage.Controls.Add(this.textBox1);
			this.internalextrapage.Controls.Add(this.label10);
			this.internalextrapage.Controls.Add(this.itemid);
			this.internalextrapage.Controls.Add(this.tileY);
			this.internalextrapage.Controls.Add(this.label9);
			this.internalextrapage.Controls.Add(this.label8);
			this.internalextrapage.Controls.Add(this.tileX);
			this.internalextrapage.Controls.Add(this.macUpdate);
			this.internalextrapage.Controls.Add(this.label7);
			this.internalextrapage.Controls.Add(this.setMac);
			this.internalextrapage.Controls.Add(this.custom_collect_y);
			this.internalextrapage.Controls.Add(this.label5);
			this.internalextrapage.Controls.Add(this.label4);
			this.internalextrapage.Controls.Add(this.custom_collect_x);
			this.internalextrapage.Controls.Add(this.expllabel);
			this.internalextrapage.Controls.Add(this.custom_collect_uid);
			this.internalextrapage.Controls.Add(this.button1);
			this.internalextrapage.Location = new global::System.Drawing.Point(4, 22);
			this.internalextrapage.Name = "internalextrapage";
			this.internalextrapage.Padding = new global::System.Windows.Forms.Padding(3);
			this.internalextrapage.Size = new global::System.Drawing.Size(500, 200);
			this.internalextrapage.TabIndex = 2;
			this.internalextrapage.Text = "Internal Extra";
			this.internalextrapage.UseVisualStyleBackColor = true;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new global::System.Drawing.Point(330, 152);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(80, 17);
			this.checkBox1.TabIndex = 19;
			this.checkBox1.Text = "aap bypass";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged_1);
			this.button3.Location = new global::System.Drawing.Point(55, 170);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(131, 23);
			this.button3.TabIndex = 18;
			this.button3.Text = "exploit";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new global::System.EventHandler(this.button3_Click_2);
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(189, 124);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(56, 13);
			this.label11.TabIndex = 17;
			this.label11.Text = "itemcount:";
			this.textBox1.Location = new global::System.Drawing.Point(192, 143);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(56, 20);
			this.textBox1.TabIndex = 16;
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(106, 124);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(40, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "itemID:";
			this.itemid.Location = new global::System.Drawing.Point(104, 143);
			this.itemid.Name = "itemid";
			this.itemid.Size = new global::System.Drawing.Size(82, 20);
			this.itemid.TabIndex = 14;
			this.tileY.Location = new global::System.Drawing.Point(55, 143);
			this.tileY.Name = "tileY";
			this.tileY.Size = new global::System.Drawing.Size(43, 20);
			this.tileY.TabIndex = 13;
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(7, 124);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(42, 13);
			this.label9.TabIndex = 12;
			this.label9.Text = "tile x: y:";
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(7, 102);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(91, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "Safe vault exploit:";
			this.tileX.Location = new global::System.Drawing.Point(6, 143);
			this.tileX.Name = "tileX";
			this.tileX.Size = new global::System.Drawing.Size(43, 20);
			this.tileX.TabIndex = 10;
			this.macUpdate.Location = new global::System.Drawing.Point(330, 123);
			this.macUpdate.Name = "macUpdate";
			this.macUpdate.Size = new global::System.Drawing.Size(75, 23);
			this.macUpdate.TabIndex = 9;
			this.macUpdate.Text = "Update Mac";
			this.macUpdate.UseVisualStyleBackColor = true;
			this.macUpdate.Click += new global::System.EventHandler(this.macUpdate_Click);
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(330, 77);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(69, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "change mac:";
			this.setMac.Location = new global::System.Drawing.Point(330, 96);
			this.setMac.Name = "setMac";
			this.setMac.Size = new global::System.Drawing.Size(100, 20);
			this.setMac.TabIndex = 7;
			this.setMac.Text = "02:bf:22:e3:77";
			this.custom_collect_y.Location = new global::System.Drawing.Point(330, 4);
			this.custom_collect_y.Name = "custom_collect_y";
			this.custom_collect_y.Size = new global::System.Drawing.Size(49, 20);
			this.custom_collect_y.TabIndex = 6;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(309, 7);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(15, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "y:";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(233, 7);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(15, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "x:";
			this.custom_collect_x.Location = new global::System.Drawing.Point(254, 4);
			this.custom_collect_x.Name = "custom_collect_x";
			this.custom_collect_x.Size = new global::System.Drawing.Size(49, 20);
			this.custom_collect_x.TabIndex = 3;
			this.expllabel.AutoSize = true;
			this.expllabel.Location = new global::System.Drawing.Point(3, 7);
			this.expllabel.Name = "expllabel";
			this.expllabel.Size = new global::System.Drawing.Size(145, 13);
			this.expllabel.TabIndex = 2;
			this.expllabel.Text = "Send collect with custom uid:";
			this.custom_collect_uid.Location = new global::System.Drawing.Point(154, 4);
			this.custom_collect_uid.Name = "custom_collect_uid";
			this.custom_collect_uid.Size = new global::System.Drawing.Size(75, 20);
			this.custom_collect_uid.TabIndex = 1;
			this.custom_collect_uid.Text = "1";
			this.button1.Location = new global::System.Drawing.Point(6, 32);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(96, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Send collect!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click_2);
			this.extraPage.Controls.Add(this.reloadLogs);
			this.extraPage.Controls.Add(this.entireLog);
			this.extraPage.Location = new global::System.Drawing.Point(4, 22);
			this.extraPage.Name = "extraPage";
			this.extraPage.Padding = new global::System.Windows.Forms.Padding(3);
			this.extraPage.Size = new global::System.Drawing.Size(511, 226);
			this.extraPage.TabIndex = 2;
			this.extraPage.Text = "Extra Logs";
			this.extraPage.UseVisualStyleBackColor = true;
			this.reloadLogs.Location = new global::System.Drawing.Point(428, 192);
			this.reloadLogs.Name = "reloadLogs";
			this.reloadLogs.Size = new global::System.Drawing.Size(75, 23);
			this.reloadLogs.TabIndex = 1;
			this.reloadLogs.Text = "Reload";
			this.reloadLogs.UseVisualStyleBackColor = true;
			this.reloadLogs.Click += new global::System.EventHandler(this.reloadLogs_Click);
			this.entireLog.Location = new global::System.Drawing.Point(3, 0);
			this.entireLog.Name = "entireLog";
			this.entireLog.Size = new global::System.Drawing.Size(505, 186);
			this.entireLog.TabIndex = 0;
			this.entireLog.Text = "";
			this.aboutlabel.AutoSize = true;
			this.aboutlabel.Location = new global::System.Drawing.Point(0, 251);
			this.aboutlabel.Name = "aboutlabel";
			this.aboutlabel.Size = new global::System.Drawing.Size(342, 39);
			this.aboutlabel.TabIndex = 7;
			this.aboutlabel.TabStop = true;
			this.aboutlabel.Text = "Made by playingo/DEERUX (Germany) and iProgramInCpp (Romania).\r\nThis project is entirely NOT based on ama6nen/enetproxy nor affiliated.\r\nthanks to n4h/abood for releasing!";
			this.aboutlabel.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutlabel_LinkClicked);
			this.vLabel.AutoSize = true;
			this.vLabel.Location = new global::System.Drawing.Point(489, 277);
			this.vLabel.Name = "vLabel";
			this.vLabel.Size = new global::System.Drawing.Size(29, 13);
			this.vLabel.TabIndex = 8;
			this.vLabel.Text = "V1.4";
			this.playerLogicUpdate.Tick += new global::System.EventHandler(this.playerLogicUpdate_Tick);
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(334, 251);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(184, 26);
			this.label14.TabIndex = 9;
			this.label14.Text = "Creator of the project: playingo\r\nalias DEERUX or realDEERUX#8998";
			this.textBox2.Location = new global::System.Drawing.Point(330, 54);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new global::System.Drawing.Size(69, 20);
			this.textBox2.TabIndex = 20;
			this.textBox2.Text = "3.33";
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(327, 38);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(122, 13);
			this.label16.TabIndex = 21;
			this.label16.Text = "spoof growtopia version:";
			this.button12.Location = new global::System.Drawing.Point(405, 52);
			this.button12.Name = "button12";
			this.button12.Size = new global::System.Drawing.Size(75, 23);
			this.button12.TabIndex = 22;
			this.button12.Text = "Apply";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new global::System.EventHandler(this.button12_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(518, 291);
			base.Controls.Add(this.label14);
			base.Controls.Add(this.vLabel);
			base.Controls.Add(this.aboutlabel);
			base.Controls.Add(this.formTabs);
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(534, 330);
			this.MinimumSize = new global::System.Drawing.Size(534, 330);
			base.Name = "MainForm";
			base.Opacity = 0.97;
			base.ShowIcon = false;
			this.Text = "Growbrew Proxy - Main Page";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			base.Load += new global::System.EventHandler(this.MainForm_Load);
			this.formTabs.ResumeLayout(false);
			this.proxyPage.ResumeLayout(false);
			this.proxyPage.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.portBox).EndInit();
			this.cheatPage.ResumeLayout(false);
			this.cheattabs.ResumeLayout(false);
			this.internalcheattab.ResumeLayout(false);
			this.internalcheattab.PerformLayout();
			this.externalcheattab.ResumeLayout(false);
			this.externalcheattab.PerformLayout();
			this.internalextrapage.ResumeLayout(false);
			this.internalextrapage.PerformLayout();
			this.extraPage.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000059 RID: 89
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.Button runproxy;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.Label statuslabel;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.Label labelsrvrunning;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.Label labelclientrunning;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400005F RID: 95
		public global::System.Windows.Forms.RichTextBox logBox;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.TabControl formTabs;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.TabPage proxyPage;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.TabPage cheatPage;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.TabPage extraPage;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.LinkLabel aboutlabel;

		// Token: 0x04000065 RID: 101
		public global::System.Windows.Forms.RichTextBox entireLog;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.Button reloadLogs;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.CheckBox hack_magplant;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.TextBox ipaddrBox;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.Button updateAddress;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.Label chnamelabel;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.TextBox changeNameBox;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.CheckBox rgbSkinHack;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.NumericUpDown portBox;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.TabControl cheattabs;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.TabPage internalcheattab;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.TabPage externalcheattab;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Button showExternalsbtn;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.LinkLabel explanatoryLabel;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.Button playerMgr;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.Label vLabel;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.CheckBox hack_autoworldbanmod;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.TabPage internalextrapage;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.Label expllabel;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.TextBox custom_collect_uid;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400007D RID: 125
		private global::System.Windows.Forms.TextBox custom_collect_y;

		// Token: 0x0400007E RID: 126
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.TextBox custom_collect_x;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.Label posXYLabel;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.Timer playerLogicUpdate;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.CheckBox cheat_speed;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Button punishview;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.TextBox nameBoxOn;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.TextBox actionButtonClicked;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Button macUpdate;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.TextBox setMac;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Button button3;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Label label11;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.TextBox itemid;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.TextBox tileY;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.TextBox tileX;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.CheckBox ghostmodskin;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.Button sendtextact;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.Button sendgameact;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.RichTextBox packetText;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.CheckBox send2client;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.Button button5;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.Button button4;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Button button6;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.CheckBox checkBox2;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.CheckBox checkBox3;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.CheckBox checkBox4;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.CheckBox checkBox5;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.Button button9;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.Button button8;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.Button button7;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Button button10;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Button button11;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.CheckBox checkBox6;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.Button button12;

        private global::System.Windows.Forms.NumericUpDown numericupdown;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.TextBox textBox2;
	}
}
