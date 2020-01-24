using UnityEditor;
using UnityEngine;

/***************************************************************************
 *   Defines Unity menu items to call external graphical SVN clients.      *
 *   It runs commands for TortoiseSVN on Windows and RabbitVCS on Linux.   *
 *   On Mac OS, it just acts as a shortcut to open SnailSVN.               *
 ***************************************************************************/

namespace TeamCitrus.SVN
{
	using Path = MenuItemPaths;
	using Argument = MenuItemArguments;
	using Command = MenuItemCommand;
	
	internal static class MenuItems
	{
		public const int BasePriority = -1000;

		// The root path of the project, targeted by Unity's menu.
		private static string ProjectPath
		{
			get
			{
				return Application.dataPath.Replace("/Assets", "");
			}
		}

		// The path of the current selection, targeted by the Project context menu.
		// Returns the first selected asset with a valid path in the Asset Database.
		private static string AssetPath
		{
			get
			{
				string path = string.Empty;
				Object[] selectedAssets = Selection.GetFiltered(typeof(Object), SelectionMode.TopLevel | SelectionMode.Assets);
				for (int index = 0; index < selectedAssets.Length; ++index)
				{
					path = AssetDatabase.GetAssetPath(selectedAssets[index]);
					if (false == string.IsNullOrEmpty(path))
					{
						break;
					}
				}
				return path;
			}
		}

		/************************
		 *   Unity Menu Items   *
		 ************************/

		#if UNITY_EDITOR_WIN || UNITY_EDITOR_LINUX

		[MenuItem(Path.MenuBar + Path.Update, false, BasePriority + 1)]
		private static void Update() { Command.Run(Argument.Update, ProjectPath); }

		[MenuItem(Path.MenuBar + Path.Commit, false, BasePriority + 2)]
		private static void Commit() { Command.Run(Argument.Commit, ProjectPath); }

		[MenuItem(Path.MenuBar + Path.Log, false, BasePriority + 50)]
		private static void ShowLog() { Command.Run(Argument.Log, ProjectPath); }

		[MenuItem(Path.MenuBar + Path.RepoBrowser, false, BasePriority + 51)]
		private static void RepoBrowser() { Command.Run(Argument.RepoBrowser, ProjectPath); }

		[MenuItem(Path.MenuBar + Path.Revert, false, BasePriority + 100)]
		private static void Revert() { Command.Run(Argument.Revert, ProjectPath); }

		[MenuItem(Path.MenuBar + Path.Settings, false, BasePriority + 150)]
		private static void Settings() { Command.Run(Argument.Settings, null); }

		[MenuItem(Path.MenuBar + Path.About, false, BasePriority + 151)]
		private static void About() { Command.Run(Argument.About, null); }
		
		#else

 		[MenuItem(Path.MenuBar + Path.Open, false, BasePriority + 1)]
 		private static void Open() { Command.Run(Argument.Open, null); }

		#endif

		/**********************************
		 *   Project Context Menu Items   *
		 **********************************/

		#if UNITY_EDITOR_WIN || UNITY_EDITOR_LINUX

		[MenuItem(Path.Assets + Path.Update, false, BasePriority + 1)]
		private static void AssetsUpdate() { Command.Run(Argument.Update, AssetPath); }

		[MenuItem(Path.Assets + Path.Commit, false, BasePriority + 1)]
		private static void AssetsCommit() { Command.Run(Argument.Commit, AssetPath); }

		[MenuItem(Path.Assets + Path.Log, false, BasePriority + 50)]
		private static void AssetsShowLog() { Command.Run(Argument.Log, AssetPath); }

		[MenuItem(Path.Assets + Path.RepoBrowser, false, BasePriority + 51)]
		private static void AssetsRepoBrowser() { Command.Run(Argument.RepoBrowser, AssetPath); }

		[MenuItem(Path.Assets + Path.Revert, false, BasePriority + 100)]
		private static void AssetsRevert() { Command.Run(Argument.Revert, AssetPath); }
		
		#else

 		[MenuItem(Path.Assets + Path.Open, false, BasePriority + 1)]
 		private static void AssetsOpen() { Command.Run(Argument.Open, null); }
		 
		#endif
	}
}
