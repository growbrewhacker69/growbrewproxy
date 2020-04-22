using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GrowbrewProxy
{
	// Token: 0x0200000F RID: 15
	public partial class PlayerForm : Form
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00002466 File Offset: 0x00000666
		public PlayerForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002474 File Offset: 0x00000674
		private void PlayerForm_Load(object sender, EventArgs e)
		{
			this.updateControls.Start();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000824C File Offset: 0x0000644C
		private void timer1_Tick(object sender, EventArgs e)
		{
			PlayerForm.updatedHeight = base.Height;
			World worldMap = MainForm.messageHandler.worldMap;
			if (worldMap != null)
			{
				this.Text = "All players in " + worldMap.currentWorld;
			}
			if (PlayerForm.requireClear)
			{
				PlayerForm.requireClear = false;
				this.playerBox.Controls.Clear();
			}
			List<PlayerForm.ControlWithMetaData> obj = PlayerForm.controlsToLoad;
			lock (obj)
			{
				foreach (PlayerForm.ControlWithMetaData controlWithMetaData in PlayerForm.controlsToLoad)
				{
					this.playerBox.Controls.Add(controlWithMetaData.control);
				}
			}
		}

		// Token: 0x040000EA RID: 234
		public static int updatedHeight = 0;

		// Token: 0x040000EB RID: 235
		public static bool requireClear = false;

		// Token: 0x040000EC RID: 236
		public static List<PlayerForm.ControlWithMetaData> controlsToLoad = new List<PlayerForm.ControlWithMetaData>();

		// Token: 0x02000010 RID: 16
		public struct ControlWithMetaData
		{
			// Token: 0x040000F0 RID: 240
			public int netID;

			// Token: 0x040000F1 RID: 241
			public Control control;
		}
	}
}
