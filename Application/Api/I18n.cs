//using System;
//using System.Collections.Generic;
//using Code.I18n.Models;
//using MySql.Data.MySqlClient;
//using SqlKata.Compilers;
//using SqlKata.Execution;

//namespace Application
//{
//	public class I18N
//	{
//		private const string connectionString = @"server=hh-sued.de;userid=d038ec20;password=Nak123!Db;database=d038ec20";
//		private const string _dataTable = "misc_I18n";
//		public Application.Collections.I18N.TranslationDataSources TranslationDataSource { get; set; } =
//			Application.Collections.I18N.TranslationDataSources.Database;
//		public string Section { get; set; } = string.Empty;
//		public string Subsection { get; set; } = string.Empty;
//		public string Language { get; set; } = "en_EN";

//		private readonly Dictionary<string, Section> _sections;

//		public I18N()
//		{
//			_sections = new Dictionary<string, Section>();
//		}

//		public I18N(Application.Collections.I18N.TranslationDataSources translationDataSource)
//		{
//			_sections = new Dictionary<string, Section>();
//			TranslationDataSource = translationDataSource;
//		}

//		public I18N(string language)
//		{
//			_sections = new Dictionary<string, Section>();
//			Language = language;
//		}

//		public I18N(string language, Application.Collections.I18N.TranslationDataSources translationDataSource)
//		{
//			_sections = new Dictionary<string, Section>();
//			Language =language;
//			TranslationDataSource = translationDataSource;
//		}
									


//		public void Load(string section, string subsection)
//		{
//			if (!_sections.ContainsKey(section))
//			{
//				_sections.Add(section, new Section(section));
//			}
//			if (_sections[section].Subsections.ContainsKey(subsection))
//			{
//				return;
//			}
//			else
//			{
//				_sections[section].AddSubsection(subsection, new Subsection(subsection));
//			}

//			Section = section;
//			Subsection = subsection;

//			var queryFactory = new QueryFactory(
//				new MySqlConnection(connectionString),
//				new MySqlCompiler());

//			var translationData = queryFactory
//				.Query(_dataTable)
//				.Select("LanguageKey","LanguageValue")
//				.Where("Language", "de_DE")
//				.Where("Section", section)
//				.Where("Subsection", subsection)
//				.Get();
//			foreach (var translationRecord in translationData)
//			{
//				_sections[section].Subsections[subsection].Records.Add(translationRecord.LanguageKey, translationRecord.LanguageValue);
//			}
//		}

//		public void SetLanguage(string language)
//		{
//			Language = language;
//		}

//		public void SetSource(Application.Collections.I18N.TranslationDataSources translationDataSources)
//		{
//			TranslationDataSource = translationDataSources;
//		}

//		public void CleanUp()
//		{

//		}

//		public string Get(string key)
//		{
//			return _(key);
//		}
//		public string t(string key)
//		{
//			return _(key);}

//		public string _(string key)
//		{
//			if (Subsection == string.Empty && Section == string.Empty) throw new Exception("Not 'Subsection' nor 'Section' are set.");

//			return 
//				!_sections[Section].
//				Subsections[Subsection]
//				.Records
//				.ContainsKey(key) 
//					? $"__Error: Key not found -> {key}__" 
//					: _sections[Section].
//						Subsections[Subsection].
//						Records[key];
//		}
//	}
//}
