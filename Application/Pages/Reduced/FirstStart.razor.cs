using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Application.Pages.Reduced
{
	public partial class FirstStart : ComponentBase
	{
		private string _appType = "localInstance";
		private string _onlineInstance = "";
		private readonly List<bool> _panelsExpansion = new List<bool>()
		{
			true,
			false,
			false,
			false,
			false,
			false
		};

		private void ExpandPanel(int oldPanel, int newPanel)
		{
			_panelsExpansion[oldPanel] = false;
			_panelsExpansion[newPanel] = true;
		}

		private void OnAppTypeSelected(string appType)
		{
			_appType = appType;
			switch (_appType)
			{
				case "localInstance":
					ExpandPanel(1,2);
					break;
				case "onlineInstance":
					ExpandPanel(1, 3);
					break;
				case "restoreConfigFile":
					ExpandPanel(1, 4);
					break;
			}
		}

		private void OnCreateLocalInstance()
		{
			//ERstelle Verzeichnisse: Data, Data/Db, Data/Files
			//Erstelle Datenbank und schreibe in die Konfig
			//Lade die Konfig als Basis-App-Konfig

		}
		private void OnUploadConfigFile() {}
	}
}

