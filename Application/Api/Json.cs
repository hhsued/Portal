using System.IO;
using System.Text.Json;

namespace Application.Api
{
	public static class Json
	{
		public static void Write(object jsonObject, string pathToJsonFile)
		{
			if (!pathToJsonFile.Contains(".json"))
			{
				pathToJsonFile = Path.Combine(pathToJsonFile, "Configuration.json");
			}

			File.WriteAllText(
				pathToJsonFile,
				JsonSerializer.Serialize(jsonObject));
		}

		public static void CreateEmptyConfigFile(string pathForConfigFile)
		{
			Write(new object() { }, Path.Combine(pathForConfigFile, "Configuration.json"));
		}

		public static bool ExistsConfigFile(string path, bool erstelleWennNichtVorhanden = true)
		{
			if (File.Exists(Path.Combine(path, "Konfiguration.json"))) return true;
			if (!erstelleWennNichtVorhanden) return false;
			CreateEmptyConfigFile(path);
			return true;

		}

		public static JsonElement Load(string path)
		{
			path = (path.Contains(".json")) ? path : Path.Combine(path, "Konfiguration.json");
			var jsonDocument = JsonDocument.Parse(File.ReadAllText(path));
			var basis = jsonDocument.RootElement;
			return basis;
		}

		public static JsonElement Get(string pathFile, string key)
		{
			return Load(pathFile).GetProperty(key);
		}

		public static JsonElement.ObjectEnumerator GetObject(string pathFile, string key)
		{
			return Load(pathFile).GetProperty(key).EnumerateObject();
		}

		public static string GetText(string pathFile, string key)
		{
			return Load(pathFile).GetProperty(key).ToString();
		}

		public static JsonElement.ArrayEnumerator GetArray(string pathFile, string key)
		{
			return Load(pathFile).GetProperty(key).EnumerateArray();

		}
	}
}