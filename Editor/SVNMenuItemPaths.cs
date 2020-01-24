/*************************************************************
 *   These are the paths that appear in the Unity menu bar   *
 *   and the context menu of the Project folder.             *
 *************************************************************/

namespace TeamCitrus.SVN
{
	internal static class MenuItemPaths
	{
		#if UNITY_EDITOR_WIN
		public const string Application = "TortoiseSVN";
		#elif UNITY_EDITOR_LINUX
		public const string Application = "RabbitVCS";
		#else
		public const string Application = "SnailSVN";
		#endif
		public const string MenuBar = Application + "/";
		public const string Assets = "Assets/" + Application + "/";
		public const string Checkout = "Checkout";
		public const string Update = "Update";
		public const string Commit = "Commit";
		public const string Add = "Add";
		public const string Revert = "Revert";
		public const string Log = "Show Log";
		public const string Lock = "Lock";
		public const string Unlock = "Unlock";
		public const string Remove = "Remove";
		public const string Rename = "Rename";
		public const string Resolve = "Resolve...";
		public const string Cleanup = "Cleanup";
		public const string RepoBrowser = "Repo-browser";
		public const string Relocate = "Relocate";
		public const string Merge = "Merge";
		public const string Export = "Export";
		public const string Properties = "Properties";
		public const string Settings = "Settings";
		public const string About = "About";
		public const string Open = "Open";
	}
}
