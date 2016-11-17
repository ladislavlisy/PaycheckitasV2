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

		public void InitEngines(Assembly setupAssembly)
		{
			//InitWithPatterns(setupAssembly, History());
			InitFromAssembly (setupAssembly);

			DefaultInstance = Engines.SingleOrDefault((e) => (e.Key.DefaultPattern)).Value;
		}

		protected abstract IList<HistoryPattern> History();

		protected abstract string NamespacePrefix();

		protected abstract string ClassnamePrefix();

		protected T DefaultInstance { get; set; }

		protected IDictionary<HistoryPattern, T> Engines { get; private set; }

		public void InitWithPatterns(Assembly setupAssembly, IList<HistoryPattern> setupPatterns)
		{
			Engines = setupPatterns.ToDictionary(t => t, t => CreateEngineFor(setupAssembly, t));
		}

		public void InitFromAssembly (Assembly setupAssembly)
		{
			var patternsList = setupAssembly.DefinedTypes.Where ((t) => (EngineType(t, NamespacePrefix (), ClassnamePrefix ()))).
			                                Select((c) => (c.Name)).ToList();
			                                                              
			//Engines = patternsList.ToDictionary (t => t, t => CreateEngineFor (setupAssembly, t));
			Engines = new Dictionary<HistoryPattern, T>();
		}

		private static bool EngineType (TypeInfo typeInfo, string engineNameSpace, string engineClassPrefix)
		{
			string typeNameSpace = typeInfo.Namespace;
			string typeClassName = typeInfo.Name;

			bool satisfyNamespace = string.Compare (typeNameSpace, engineNameSpace, System.StringComparison.Ordinal) == 0;
			bool satisfyClassName = typeClassName.StartsWith (engineClassPrefix, System.StringComparison.Ordinal);
			bool satisfyInterface = TypeHelpers.IsAssignableTo<T> (typeInfo);

			return typeInfo.IsClass && satisfyNamespace && satisfyClassName && satisfyInterface;
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

		private T CreateEngineFor(Assembly setupAssembly, HistoryPattern pattern)
		{
			T engine = EngineFactory<T>.InstanceFor(setupAssembly, NamespacePrefix(), ClassnamePrefix(), pattern);

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
