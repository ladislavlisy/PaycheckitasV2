using System;
using System.Collections.Generic;
using System.Reflection;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService
{
	public class EmployEnginesHistory : GeneralEnginesHistory<IEmployEngine>
	{
		private const string NAME_SPACE_PREFIX = "Paycheckitas.CountryService.History.EmployEngines";

		private const string CLASS_NAME_PREFIX = "EmployEngine";

		private const ushort DEFAULT_YEAR = 2016;

		private readonly IList<HistoryPattern> DEFAULT_HISTORY;

		private EmployEnginesHistory()
		{
		}

		public static IEnginesHistory<IEmployEngine> CreateInstance()
		{
			return new EmployEnginesHistory();
		}

		public static IEnginesHistory<IEmployEngine> CreateEngines()
		{
			IEnginesHistory<IEmployEngine> engine = CreateInstance();

			engine.InitEngines();

			return engine;
		}

		#region implemented abstract members of GeneralEngines

		protected override ushort DefaultYear()
		{
			return DEFAULT_YEAR;
		}

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

		protected override Assembly HistoryAssembly()
		{
			return typeof(CountryServiceModule).Assembly();
		}

		#endregion
	}
}
