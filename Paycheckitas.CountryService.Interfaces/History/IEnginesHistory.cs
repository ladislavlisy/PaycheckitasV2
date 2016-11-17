using System.Collections.Generic;
using System.Reflection;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface IEnginesHistory<T>
	{
		void InitEngines(Assembly setupAssembly);

		void InitWithPatterns(Assembly setupAssembly, IList<HistoryPattern> setupPatterns);

		T ResolveEngine(Period period);

		T DefaultEngine();
	}
}
