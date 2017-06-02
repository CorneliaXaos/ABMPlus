using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AssetBundles
{
	public static class Utility
	{
		#region Constants

		public const string ASSET_BUNDLES_OUTPUT_PATH = "AssetBundles";

		#endregion

		#region Public Interface

		/**
		 * Converts the Unity BuildTarget / Platform Name into a C# String.
		 */
		public static string GetPlatformName ()
		{
			#if UNITY_EDITOR
			return GetPlatformForAssetBundles (EditorUserBuildSettings.activeBuildTarget);
			#else
            return GetPlatformForAssetBundles (Application.platform);
			#endif
		}

		public static string GetExecutableName (BuildTarget target)
		{
			switch (target) {
				case BuildTarget.Android:
					return "/test.apk";
				case BuildTarget.StandaloneLinux:
					return "/test.x86";
				case BuildTarget.StandaloneLinux64:
					return "/test.x86_64";
				case BuildTarget.StandaloneLinuxUniversal:
					return "/test.bin";
				case BuildTarget.StandaloneOSXIntel:
				case BuildTarget.StandaloneOSXIntel64:
				case BuildTarget.StandaloneOSXUniversal:
					return "/test.app";
				case BuildTarget.StandaloneWindows:
				case BuildTarget.StandaloneWindows64:
					return "/test.exe";
				case BuildTarget.WebPlayer:
				case BuildTarget.WebPlayerStreamed:
				case BuildTarget.WebGL:
				case BuildTarget.iOS:
					return "";
			// Add more build targets for your own.
				default:
					Debug.LogError ("Target not implemented.");
					return null;
			}
		}

		#endregion

		#region Private Interface

		#if UNITY_EDITOR
		/**
		 * Stringifies the BuildTarget.  Results are identical to the RuntimePlatform variant of this method.
		 */
		private static string GetPlatformForAssetBundles (BuildTarget target)
		{
			switch (target) {
				case BuildTarget.Android:
					return "Android";
				case BuildTarget.iOS:
					return "iOS";
				case BuildTarget.StandaloneLinux:
				case BuildTarget.StandaloneLinux64:
				case BuildTarget.StandaloneLinuxUniversal:
					return "Linux";
				case BuildTarget.StandaloneOSXIntel:
				case BuildTarget.StandaloneOSXIntel64:
				case BuildTarget.StandaloneOSXUniversal:
					return "OSX";
				#if UNITY_TVOS
				case BuildTarget.tvOS:
					return "tvOS";
				#endif
				case BuildTarget.WebGL:
					return "WebGL";
				case BuildTarget.WebPlayer:
					return "WebPlayer";
				case BuildTarget.StandaloneWindows:
				case BuildTarget.StandaloneWindows64:
					return "Windows";
			// Add more build targets here if you're missing one!  Don't forget to do the same for the function below!
				default:
					return null;
			}
		}
		#endif

		/**
		 * Stringifies the RuntimePlatform.  Results are identical to the BuildTarget variant of this method.
		 */
		private static string GetPlatformForAssetBundles (RuntimePlatform platform)
		{
			switch (platform) {
				case RuntimePlatform.Android:
					return "Android";
				case RuntimePlatform.IPhonePlayer:
					return "iOS";
				case RuntimePlatform.LinuxPlayer:
					return "Linux";
				case RuntimePlatform.OSXPlayer:
					return "OSX";
				#if UNITY_TVOS
				case RuntimePlatform.tvOS:
					return "tvOS";
				#endif
				case RuntimePlatform.WebGLPlayer:
					return "WebGL";
				case RuntimePlatform.OSXWebPlayer:
				case RuntimePlatform.WindowsWebPlayer:
					return "WebPlayer";
				case RuntimePlatform.WindowsPlayer:
					return "Windows";
			// Add more build targets here if you're missing one!  Don't forget to do the same for the function below!
				default:
					return null;
			}
		}

		#endregion
	}
}
