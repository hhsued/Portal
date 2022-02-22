namespace Application.Collections.I18n
{
	public static class de_De
	{
		private static string OneChar(string value)
		{
			return value switch
			{
				"0" => "null",
				"1" => "eins",
				"2" => "zwei",
				"3" => "drei",
				"4" => "vier",
				"5" => "fünf",
				"6" => "sechs",
				"7" => "sieben",
				"8" => "acht",
				"9" => "neun",
				_ => string.Empty
			};
		}

		private static string TwoChars(string value)
		{
			return value switch
			{
				"10" => "zehn",
				"11" => "elf",
				"12" => "zwölf",
				_ => string.Empty
			};
		}

		public static string NumberToWord(int number)
		{
			var numberString = number.ToString();

			switch (numberString.Length)
			{
				case 1:
					break;
			}

			return string.Empty;
		}
	}
}
