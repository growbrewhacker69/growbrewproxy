using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace GrowbrewProxy
{
	// Token: 0x0200000A RID: 10
	public class HTTPServer
	{
		// Token: 0x0600005E RID: 94 RVA: 0x000080A4 File Offset: 0x000062A4
		public static void HTTPHandler()
		{
			while (HTTPServer.listener.IsListening)
			{
				HttpListenerContext context = HTTPServer.listener.GetContext();
				HttpListenerRequest request = context.Request;
				HttpListenerResponse response = context.Response;
				Console.WriteLine(string.Concat(new string[]
				{
					"New request from client:\n",
					request.RawUrl,
					" ",
					request.HttpMethod,
					" ",
					request.UserAgent
				}));
				if (request.HttpMethod == "POST")
				{
					byte[] bytes = Encoding.UTF8.GetBytes("server|127.0.0.1\nport|2\ntype|1\nbeta_server|127.0.0.1\nbeta_port|2\nmeta|growbrew\n");
					response.ContentLength64 = (long)bytes.Length;
					Stream outputStream = response.OutputStream;
					outputStream.Write(bytes, 0, bytes.Length);
					outputStream.Close();
				}
			}
			HTTPServer.listener.Stop();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000816C File Offset: 0x0000636C
		public static void StartHTTP(string[] prefixes)
		{
			Console.WriteLine("Setting up HTTP Server...");
			if (!HttpListener.IsSupported)
			{
				Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
				return;
			}
			if (prefixes == null || prefixes.Length == 0)
			{
				throw new ArgumentException("prefixes");
			}
			foreach (string uriPrefix in prefixes)
			{
				HTTPServer.listener.Prefixes.Add(uriPrefix);
			}
			HTTPServer.listener.Start();
			if (HTTPServer.listener.IsListening)
			{
				Console.WriteLine("Listening!");
			}
			else
			{
				Console.WriteLine("Could not listen to port 80, an error occured!");
			}
			new Thread(new ThreadStart(HTTPServer.HTTPHandler)).Start();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002050 File Offset: 0x00000250
		public static void StopHTTP()
		{
		}

		// Token: 0x040000B5 RID: 181
		private static string Version = "HTTP/1.0";

		// Token: 0x040000B6 RID: 182
		private static HttpListener listener = new HttpListener();
	}
}
