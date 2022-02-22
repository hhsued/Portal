//namespace Code
//{
//	public static class Scribus
//	{
//		public const double ScribusToMm = 2.83464566929134;

//		private static readonly Dictionary<string, XDocument> _xmlScribusFiles = new Dictionary<string, XDocument>();
//		private static readonly Dictionary<string, XElement> _xmlScribusDocuments = new Dictionary<string, XElement>();

//		public static void Clear()
//		{
//			_xmlScribusFiles.Clear();
//			_xmlScribusDocuments.Clear();
//		}

//		public static void CreateFirstPage(string congregation, int month, int year, string citeText, string citeLocation)
//		{
//			/*var bildAttribute = Konfiguration.Konfig["Gemeindebrief"].GetProperty("ErsteSeite").GetProperty(congregation).GetProperty("Bild").EnumerateObject();

//			if (!_xmlScribusFiles.ContainsKey("VorlageErsteSeite"))
//			{
//			    _xmlScribusFiles.Add("VorlageErsteSeite", XDocument.Load(
//			        Path.Combine(
//			            Directory.GetCurrentDirectory(),
//			            "Vorlagen",
//			            "ErsteSeite.sla")));
//			}

//			_xmlScribusFiles.Add("NeueAusgabe", XDocument.Load(
//			    Path.Combine(
//			        Directory.GetCurrentDirectory(),
//			        "Vorlagen",
//			        "LeereSeite.sla")));
//			_xmlScribusDocuments.Add("NeueAusgabe", _xmlScribusFiles["NeueAusgabe"].Descendants("DOCUMENT").First());

//			var neueAusgabeDatei = _xmlScribusFiles["NeueAusgabe"];
//			var neueAusgabeDokument = _xmlScribusDocuments["NeueAusgabe"];

//			// Elements with images
//			neueAusgabeDokument.Add(
//			    ErsteSeite.SetzeBild(
//			        "S1_NAK_Logo",
//			        @"C:\Users\ckoeste1\Nextcloud\Gemeindebriefe\Zubehör\Logo\Logo_Text_rechts.png"));
//			neueAusgabeDokument.Add(
//			    ErsteSeite.SetzeBild(
//			        "S1_Gemeindebild",
//			        @"C:\Users\ckoeste1\Nextcloud\Gemeindebriefe\Zubehör\Gemeinden\" + congregation + ".jpg",
//			        alleAttribute: bildAttribute));

//			// Elements with no needs to change
//			neueAusgabeDokument.Add(ErsteSeite.FindeElement("S1_Gemeindebrief"));
//			neueAusgabeDokument.Add(ErsteSeite.FindeElement("S1_Digital"));
//			neueAusgabeDokument.Add(ErsteSeite.FindeElement("S1_Blaue_Linie"));

//			// Elements that should get a new content
//			neueAusgabeDokument.Add(
//			    ErsteSeite.SetzeInhalt(
//			        "S1_Monat",
//			        Helfer.DatumZeit.IntegerNachMonat(month) + " " + year.ToString()));
//			neueAusgabeDokument.Add(
//			    ErsteSeite.SetzeInhalt(
//			        "S1_Gemeinde",
//			        congregation));
//			neueAusgabeDokument.Add(
//			    ErsteSeite.SetzeInhalt(
//			        "S1_Zitat",
//			        citeText,
//			        citeLocation));
//			neueAusgabeDatei.Save(
//			    Path.Combine(
//			        @"C:\Users\ckoeste1\Nextcloud\Gemeindebriefe\Ausgaben",
//			        year.ToString(),
//			        Helfer.DatumZeit.ZweiZeichenMonat(month),
//			        congregation,
//			        "Ausgabe.sla"
//			    ));

//			_xmlScribusFiles.Remove("NeueAusgabe");
//			_xmlScribusDocuments.Remove("NeueAusgabe");*/
//		}

//		/// <summary>
//		/// All methods for the first page.
//		/// </summary>
//		internal static class ErsteSeite
//		{
//			/// <summary>
//			/// 
//			/// </summary>
//			/// <param Name="elementName"></param>
//			/// <param Name="bildPfad"></param>
//			/// <param Name="alleAttribute"></param>
//			/// <returns></returns>
//			public static XElement SetzeBild(string elementName, string bildPfad,
//				JsonElement.ObjectEnumerator alleAttribute)
//			{
//				var seitenObjekt = SetzeBild(elementName, bildPfad);
//				foreach (var attribute in alleAttribute)
//				{
//					switch (attribute.Name)
//					{
//						case "Skalierung":
//							seitenObjekt.SetAttributeValue("LOCALSCX", attribute.Value);
//							seitenObjekt.SetAttributeValue("LOCALSCY", attribute.Value);
//							break;
//						case "PosX":
//							seitenObjekt.SetAttributeValue("LOCALX", attribute.Value);
//							break;
//						case "PosY":
//							seitenObjekt.SetAttributeValue("LOCALY", attribute.Value);
//							break;
//						case "Aufloesung":
//							seitenObjekt.SetAttributeValue("ImageRes", attribute.Value);
//							break;
//					}
//				}

//				return seitenObjekt;
//			}

//			public static XElement SetzeBild(string elementName, string bildPfad)
//			{
//				var seitenObjekt = FindeElement(elementName);
//				seitenObjekt!.SetAttributeValue("PFILE", bildPfad);

//				return seitenObjekt;
//			}

//			public static XElement SetzeInhalt(string elementName, params string[] inhalte)
//			{
//				var inhaltsZaehler = 0;
//				var seitenObjekt = FindeElement(elementName);

//				foreach (var textElement in seitenObjekt?.Descendants(XName.Get("ITEXT"))!.ToArray()!)
//				{
//					textElement.SetAttributeValue("CH", inhalte[inhaltsZaehler]);
//					inhaltsZaehler++;
//				}

//				return seitenObjekt;
//			}

//			public static IEnumerable<XElement>? FindeElemente(string elementName, string? attributName = null)
//			{
//				attributName ??= "ANNAME";
//				var elemente = Scribus._xmlScribusFiles["VorlageErsteSeite"]?.Descendants(XName.Get("PAGEOBJECT"))
//					.Where(element => (string)element.Attribute(attributName)! == elementName);
//				return elemente;
//			}

//			public static XElement? FindeElement(string elementName)
//			{
//				return FindeElemente(elementName)!.First();
//			}
//		}
//	}