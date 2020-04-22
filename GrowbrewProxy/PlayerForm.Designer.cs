namespace GrowbrewProxy
{
	// Token: 0x0200000F RID: 15
	public partial class PlayerForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00002481 File Offset: 0x00000681
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00008324 File Offset: 0x00006524
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.playerBox = new global::System.Windows.Forms.GroupBox();
			this.updateControls = new global::System.Windows.Forms.Timer(this.components);
			base.SuspendLayout();
			this.playerBox.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.playerBox.Location = new global::System.Drawing.Point(0, 0);
			this.playerBox.Name = "playerBox";
			this.playerBox.Size = new global::System.Drawing.Size(605, 333);
			this.playerBox.TabIndex = 0;
			this.playerBox.TabStop = false;
			this.playerBox.Text = "Player Box";
			this.updateControls.Interval = 1000;
			this.updateControls.Tick += new global::System.EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(605, 333);
			base.Controls.Add(this.playerBox);
			this.MinimumSize = new global::System.Drawing.Size(621, 372);
			base.Name = "PlayerForm";
			base.ShowIcon = false;
			this.Text = "All players in EXIT";
			base.Load += new global::System.EventHandler(this.PlayerForm_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040000ED RID: 237
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000EE RID: 238
		public global::System.Windows.Forms.GroupBox playerBox;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Timer updateControls;
	}
}
