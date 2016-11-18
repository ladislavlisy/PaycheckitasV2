using System.Collections.Generic;
using System.Reflection;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService
{
	public class SocialEnginesHistory : GeneralEnginesHistory<ISocialEngine>
	{
		private const string NAME_SPACE_PREFIX = "Paycheckitas.CountryService.History.SocialEngines";

		private const string CLASS_NAME_PREFIX = "SocialEngine";

		private readonly IList<HistoryPattern> DEFAULT_HISTORY = new List<HistoryPattern> () { HistoryPattern.DefaultYear (2016) };

		private SocialEnginesHistory ()
		{
		}

		public static IEnginesHistory<ISocialEngine> CreateInstance ()
		{
			return new SocialEnginesHistory ();
		}

		public static IEnginesHistory<ISocialEngine> CreateEngines (Assembly setupAssembly)
		{
			IEnginesHistory<ISocialEngine> enginesHistory = CreateInstance ();

			enginesHistory.InitEngines (setupAssembly);

			return enginesHistory;
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
