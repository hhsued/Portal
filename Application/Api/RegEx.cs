using System.Text.RegularExpressions;

namespace Application.Api
{
	public static class RegEx
	{
		public static bool Exists(string pattern, string searchString)
		{
			var regexObject = new Regex(pattern);
			var matchCollection = regexObject.Matches(searchString);
			return matchCollection.Count > 0;
		}
	}
}