using UnityEditor;
using System.Diagnostics;
using System.Text;
using Debug = UnityEngine.Debug;

/***************************************************************
 *   This is the logic for calling external SVN GUI clients.   *
 ***************************************************************/

namespace TeamCitrus.SVN
{
	internal static class MenuItemCommand
	{
		#if UNITY_EDITOR_WIN
		public const string Application = "cmd";
		#elif UNITY_EDITOR_LINUX
		public const string Application = "rabbitvcs";
		#else
		public const string Application = "/Applications/SnailSVN.app";
		#endif

		private static Process commandProcess;
		private static Process CommandProcess
		{
			get
			{
				commandProcess = null;
				if (null == commandProcess)
				{
					ProcessStartInfo startInfo = new ProcessStartInfo();
					#if UNITY_EDITOR_WIN || UNITY_EDITOR_LINUX
					startInfo.UseShellExecute = false;
					startInfo.RedirectStandardInput = false;
					startInfo.RedirectStandardOutput = true;
					startInfo.RedirectStandardError = true;
					Encoding outputEncoding = Encoding.GetEncoding(System.Console.OutputEncoding.CodePage);
					startInfo.StandardOutputEncoding = outputEncoding;
					startInfo.StandardErrorEncoding = outputEncoding;
					#else
					startInfo.UseShellExecute = true;
					#endif
					startInfo.CreateNoWindow = true;
					commandProcess = new Process();
					commandProcess.StartInfo = startInfo;
				}
				return commandProcess;
			}
		}
		
		public static void Run(string command, string path)
		{
			Process process = null;
			try
			{
				process = CommandProcess;
				process.StartInfo.FileName = Application;
				process.StartInfo.Arguments = BuildCommand(command, path);
				process.Start();
				#if UNITY_EDITOR_WIN || UNITY_EDITOR_LINUX
				process.StandardOutput.ReadToEnd();
				string error = process.StandardError.ReadToEnd();
				if (false == string.IsNullOrEmpty(error))
				{
					#if UNITY_EDITOR_WIN
					Debug.LogError("[SVN Menu] " + error);
					#endif
				}
				#endif
				process.WaitForExit();
				process.Close();
				AssetDatabase.Refresh(ImportAssetOptions.Default);
			}
			catch (System.Exception e)
			{
				Debug.LogError("[SVN Menu] An exception occurred:");
				Debug.LogException(e);
				if (null != process)
				{
					process.Close();
				}
			}
		}

		private static string BuildCommand(string command, string path)
		{
			StringBuilder cmd = new StringBuilder();
			#if UNITY_EDITOR_WIN
			cmd.Append("/c TortoiseProc.exe /command:");
			cmd.Append(command);
			if (null != path)
			{
				cmd.Append(" /path:\"");
				cmd.Append(path);
				cmd.Append("\"");
			}
			if (null != path)
			{
				cmd.Append(" /closeonend:0");
			}
			#elif UNITY_EDITOR_LINUX
			cmd.Append(command);
			if (null != path)
			{
				cmd.Append(" \"");
				cmd.Append(path);
				cmd.Append("\"");
			}
			#else
			// Commands are not yet supported on Mac OS
			#endif
			return cmd.ToString();
		}
	}
}
