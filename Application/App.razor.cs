using System;
using System.IO;
using System.Threading.Tasks;
using Application.Api;
using Microsoft.AspNetCore.Components;

namespace Application
{
	public partial class App : ComponentBase
	{
		private void InitApplication()
		{
			Container.ApplicationContainer.OperatingSystem = Misc.GetOperatingSystem();
			Container.ApplicationContainer.OperatingSystemType = Misc.GetOperatingSystemType(Container.ApplicationContainer.OperatingSystem);
			CheckForFirstStart();

		}
		private void CheckForFirstStart()
		{
			var configPath = Path.Combine(Environment.CurrentDirectory, "Config");
			if (Directory.Exists(configPath)) return;
			_navigationManager.NavigateTo("FirstStart");
		}
	}
}
