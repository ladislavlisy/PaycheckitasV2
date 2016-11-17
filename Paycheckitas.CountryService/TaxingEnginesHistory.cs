using System.Collections.Generic;
using System.Reflection;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService
{
	public class TaxingEnginesHistory : GeneralEnginesHistory<ITaxingEngine>
	{
		private const string NAME_SPACE_PREFIX = "Paycheckitas.CountryService.History.TaxingEngines";

		private const string CLASS_NAME_PREFIX = "TaxingEngine";

		private readonly IList<HistoryPattern> DEFAULT_HISTORY = new List<HistoryPattern> () { HistoryPattern.Year (2016) };

		private TaxingEnginesHistory ()
		{
		}

		public static IEnginesHistory<ITaxingEngine> CreateInstance ()
		{
			return new TaxingEnginesHistory ();
		}

		public static IEnginesHistory<ITaxingEngine> CreateEngines (Assembly setupAssembly)
		{
			IEnginesHistory<ITaxingEngine> engine = CreateInstance ();

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
