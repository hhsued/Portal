using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.Models.I18n
{
	public class Subsection
	{
		public string Name { get; private set; } = string.Empty;
		public Dictionary<string, string> Records { get; set; }
		private System.DateTime _creationDateTime;

		public Subsection(string name)
		{
			Name = name;
			Records = new Dictionary<string, string>();
			_creationDateTime = System.DateTime.Now;
		}
	}

	public class Section
	{
		public string Name { get; private set; } = string.Empty;
		public Dictionary<string, Subsection> Subsections { get; set; }
		private System.DateTime _creationDateTime { get; set; }

		public Section(string name)
		{
			Name = name;
			Subsections = new Dictionary<string, Subsection>();
			_creationDateTime = System.DateTime.Now;
		}

		public Section AddSubsection(string moduleName, Subsection subsection)
		{
			Subsections.Add(moduleName, subsection);
			return this;
		}

	}
}
