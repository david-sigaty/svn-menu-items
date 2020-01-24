/*********************************************************************
 *   These are the arguments used to invoke different functions      *
 *   of graphical SVN programs. SnailSVN currently only uses Open.   *
 *********************************************************************/

namespace TeamCitrus.SVN
{
	internal static class MenuItemArguments
	{
		#if UNITY_EDITOR_WIN
		public const string RepoBrowser = "repobrowser";
		#elif UNITY_EDITOR_LINUX
		public const string RepoBrowser = "browser";
		#else
		public const string RepoBrowser = "";
		#endif
		public const string Checkout = "checkout";
		public const string Update = "update";
		public const string Commit = "commit";
		public const string Add = "add";
		public const string Revert = "revert";
		public const string Log = "log";
		public const string Lock = "lock";
		public const string Unlock = "unlock";
		public const string Remove = "remove";
		public const string Rename = "rename";
		public const string Resolve = "resolve";
		public const string Cleanup = "cleanup";
		public const string Relocate = "relocate";
		public const string Merge = "merge";
		public const string Export = "export";
		public const string Properties = "properties";
		public const string Settings = "settings";
		public const string About = "about";
		public const string Open = "open";
	}
}
