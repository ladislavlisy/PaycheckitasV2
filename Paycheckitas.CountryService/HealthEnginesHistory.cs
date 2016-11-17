using System.Collections.Generic;
using System.Reflection;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService
{
	public class HealthEnginesHistory : GeneralEnginesHistory<IHealthEngine>
	{
		private const string NAME_SPACE_PREFIX = "Paycheckitas.CountryService.History.HealthEngines";

		private const string CLASS_NAME_PREFIX = "HealthEngine";

		private readonly IList<HistoryPattern> DEFAULT_HISTORY = new List<HistoryPattern> () { HistoryPattern.Year (2016) };

		private HealthEnginesHistory ()
		{
		}

		public static IEnginesHistory<IHealthEngine> CreateInstance ()
		{
			return new HealthEnginesHistory ();
		}

		public static IEnginesHistory<IHealthEngine> CreateEngines (Assembly setupAssembly)
		{
			IEnginesHistory<IHealthEngine> engine = CreateInstance ();

			engine.InitEngines (setupAssembly);

			return engine;
		}

		#region implemented abstract members of GeneralEngines

		protected override IList<HistoryPattern> History ()
		{
			return DEFAULT_HISTORY;
		}

		protected override string NamespacePrefix ()
		{
			return NAME_SPACE_PREFIX;
		}

		protected override string ClassnamePrefix ()
		{
			return CLASS_NAME_PREFIX;
		}

		#endregion
	}
}
