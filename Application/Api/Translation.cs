//namespace Application.Api
//{

//	public static static class Translation
//	{
//		private static string Language = string.Empty;
//		private static string[] LanguageStrings = new string[] { };
//		public static void ChangeLanguage(string language)
//		{
//			Language = language;
//		}
//		private void LoadLanguageFile()
//		{
//			//$lstrPath = ((strstr($_SERVER['SCRIPT_FILENAME'], 'index.php')) ? str_replace('index.php', "", $_SERVER['SCRIPT_FILENAME']) : $_SERVER['SCRIPT_FILENAME']);
//			//$lstrPath .=   'app'.DS.'translation'.DS.$this->Language.'.json';
//			//$this->LanguageStrings = json_decode(file_get_contents($lstrPath), true);
//		}
//		public static string Translate(string String)
//		{
//			if (this.LanguageStrings.Length == 0)
//			{
//				this.LoadLanguageFile();
//			}
//			//return this.LanguageStrings[String];
//			return null;
//		}
//		public static string Table(string Table)
//		{
//			switch (Table)
//			{
//				case "urgentEntries":
//					Table = "info_urgentEntries";
//					break;
//			}
//			return Table;
//		}
//	}
//}