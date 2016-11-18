using System.Collections.Generic;
using System.Reflection;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService
{
	public class EmployEnginesHistory : GeneralEnginesHistory<IEmployEngine>
	{
		private const string NAME_SPACE_PREFIX = "Paycheckitas.CountryService.History.EmployEngines";

		private const string CLASS_NAME_PREFIX = "EmployEngine";

		private readonly IList<HistoryPattern> DEFAULT_HISTORY = new List<HistoryPattern> () { HistoryPattern.DefaultYear(2016) };

		private EmployEnginesHistory()
		{
		}

		public static IEnginesHistory<IEmployEngine> CreateInstance()
		{
			return new EmployEnginesHistory();
		}

		public static IEnginesHistory<IEmployEngine> CreateEngines(Assembly setupAssembly)
		{
			IEnginesHistory<IEmployEngine> enginesHistory = CreateInstance();

			enginesHistory.InitEngines(setupAssembly);

			return enginesHistory;
		}

		#region implemented abstract members of GeneralEngines

		protected override IList<HistoryPattern> History()
		{
			return DEFAULT_HISTORY;
		}

		protected override string NamespacePrefix()
		{
			return NAME_SPACE_PREFIX;
		}

		protected override string ClassnamePrefix()
		{
			return CLASS_NAME_PREFIX;
		}

		#endregion
	}
}
