using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetEnv;
using Markdig.Extensions.ListExtras;

namespace Final_Project
{
	internal static class Program
	{
		public static AuthenticationService authService;
		/// <summary>
		/// 應用程式的主要進入點。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Env.Load();
			string server = Env.GetString("DB_SERVER");
			string filePath = Env.GetString("DB_FILE_PATH");
			string security = Env.GetString("DB_SECURITY");

			// 確保所有變數都有值，否則拋出異常
			if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(security))
			{
				throw new Exception("Missing one or more environment variables for database configuration.");
			}

			// 拼接完整的連接字串
			string connectionString = $"Data Source={server};AttachDbFilename={filePath};{security}";


			authService = new AuthenticationService(connectionString);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new LoginPage());
		}

	}
}
