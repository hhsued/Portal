using System;

namespace Application.Api
{
	public static class Misc
	{
		public static Application.Collections.Misc.OperatingSystems GetOperatingSystem()
		{
			if (OperatingSystem.IsOSPlatform("Android")) return Application.Collections.Misc.OperatingSystems.Android;
			if (OperatingSystem.IsOSPlatform("Browser")) return Application.Collections.Misc.OperatingSystems.Browser;
			if (OperatingSystem.IsOSPlatform("FreeBSD")) return Application.Collections.Misc.OperatingSystems.FreeBsd;
			if (OperatingSystem.IsOSPlatform("IOS")) return Application.Collections.Misc.OperatingSystems.iOs;
			if (OperatingSystem.IsOSPlatform("Linux")) return Application.Collections.Misc.OperatingSystems.Linux;
			if (OperatingSystem.IsOSPlatform("MacCatalyst"))
				return Application.Collections.Misc.OperatingSystems.MacCatalyst;
			if (OperatingSystem.IsOSPlatform("MacOS")) return Application.Collections.Misc.OperatingSystems.MacOs;
			if (OperatingSystem.IsOSPlatform("TvOS")) return Application.Collections.Misc.OperatingSystems.TvOs;
			if (OperatingSystem.IsOSPlatform("WatchOS")) return Application.Collections.Misc.OperatingSystems.WatchOs;
			if (OperatingSystem.IsOSPlatform("Windows")) return Application.Collections.Misc.OperatingSystems.Windows;
			return Application.Collections.Misc.OperatingSystems.Undefined;
		}

		public static Application.Collections.Misc.OperatingSystemTypes GetOperatingSystemType(
			Application.Collections.Misc.OperatingSystems operatingSystem)
		{
			return operatingSystem switch
			{
				Application.Collections.Misc.OperatingSystems.Android => Application.Collections.Misc.OperatingSystemTypes
					.Mobile,
				Application.Collections.Misc.OperatingSystems.iOs => Application.Collections.Misc.OperatingSystemTypes.Mobile,
				Application.Collections.Misc.OperatingSystems.Browser => Application.Collections.Misc.OperatingSystemTypes
					.Browser,
				Application.Collections.Misc.OperatingSystems.FreeBsd => Application.Collections.Misc.OperatingSystemTypes
					.Desktop,
				Application.Collections.Misc.OperatingSystems.Linux => Application.Collections.Misc.OperatingSystemTypes
					.Desktop,
				Application.Collections.Misc.OperatingSystems.MacCatalyst => Application.Collections.Misc.OperatingSystemTypes
					.Desktop,
				Application.Collections.Misc.OperatingSystems.Windows => Application.Collections.Misc.OperatingSystemTypes
					.Desktop,
				Application.Collections.Misc.OperatingSystems.WatchOs => Application.Collections.Misc.OperatingSystemTypes
					.Watch,
				Application.Collections.Misc.OperatingSystems.TvOs => Application.Collections.Misc.OperatingSystemTypes.Tv,
				Application.Collections.Misc.OperatingSystems.Undefined => Application.Collections.Misc.OperatingSystemTypes
					.Desktop,
				Application.Collections.Misc.OperatingSystems.MacOs => Application.Collections.Misc.OperatingSystemTypes
					.Desktop,
				_ => Application.Collections.Misc.OperatingSystemTypes.Desktop
			};
		}

		public static string CreateGuid()
		{
			const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var guid = string.Empty;

			for (var counter = 1; counter <= 10; counter++)
			{
				switch (new Random().Next(1, 3))
				{
					case 1:
						guid += characters[new Random().Next(1, 26)].ToString().ToLower();
						break;
					case 2:
						guid += new Random().Next(0, 9).ToString();
						break;
					case 3:
						guid += characters[new Random().Next(1, 26)].ToString();
						break;
				}
			}

			return guid;
		}
	}
}