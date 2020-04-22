using System;
using System.Windows.Forms;

namespace GrowbrewProxy
{
	// Token: 0x02000011 RID: 17
	internal static class Program
	{
		// Token: 0x06000070 RID: 112 RVA: 0x000024B8 File Offset: 0x000006B8
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
