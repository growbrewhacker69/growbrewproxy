using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace GrowbrewProxy.Properties
{
	// Token: 0x0200001E RID: 30
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class Resources
	{
		// Token: 0x0600009D RID: 157 RVA: 0x00002052 File Offset: 0x00000252
		internal Resources()
		{
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000269E File Offset: 0x0000089E
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("GrowbrewProxy.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600009F RID: 159 RVA: 0x000026CA File Offset: 0x000008CA
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x000026D1 File Offset: 0x000008D1
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400013F RID: 319
		private static ResourceManager resourceMan;

		// Token: 0x04000140 RID: 320
		private static CultureInfo resourceCulture;
	}
}
