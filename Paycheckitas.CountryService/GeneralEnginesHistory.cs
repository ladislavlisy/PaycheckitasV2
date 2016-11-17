using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Paycheckitas.Common;
using Paycheckitas.Common.Core;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService
{
	public abstract class GeneralEnginesHistory<T> : IEnginesHistory<T>
	{
		public GeneralEnginesHistory()
		{
			DefaultInstance = default(T);
		}

		public void InitEngines()
		{
			InitWithPatterns(History());

			DefaultInstance = ResolveEngine(DefaultPeriod());
		}

		protected abstract ushort DefaultYear();

		protected abstract IList<HistoryPattern> History();

		protected abstract Assembly HistoryAssembly();

		protected abstract string NamespacePrefix();

		protected abstract string ClassnamePrefix();

		protected T DefaultInstance { get; set; }

		protected IDictionary<HistoryPattern, T> Engines { get; private set; }

		protected Period DefaultPeriod()
		{
			return PeriodOperations.BeginYear(DefaultYear());
		}

		public void InitWithPatterns(IList<HistoryPattern> setupPatterns)
		{
			Engines = setupYears.ToDictionary(t => t, t => CreateEngineFor(t));
		}

		public T ResolveEngine(Period period)
		{
			HistoryPattern periodPattern = PatternFromEngines(period);
			if (periodPattern == null)
			{
				return DefaultInstance;
			}
			T baseEngine;
			if (Engines.ContainsKey(periodPattern))
			{
				baseEngine = Engines[periodPattern];
			}
			else
			{
				baseEngine = DefaultInstance;
			}
			return baseEngine;
		}

		public T DefaultEngine()
		{
			return DefaultInstance;
		}

		private T CreateEngineFor(HistoryPattern pattern)
		{
			T engine = EngineFactory<T>.InstanceFor(HistoryAssembly(), NamespacePrefix(), ClassnamePrefix(), pattern);

			return engine;
		}

		private HistoryPattern PatternFromEngines(Period period)
		{
			ICollection<HistoryPattern> sortedHistory = Engines.Keys.OrderBy(x => x).ToArray();

			HistoryPattern validSpan = sortedHistory.FirstOrDefault((x) => (period.Year >= x.YearFrom && period.Year <= x.YearUpto));

			return validSpan;
		}

	}
}
