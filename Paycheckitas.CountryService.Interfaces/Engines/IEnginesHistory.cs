using System;
using System.Collections.Generic;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface IEnginesHistory<T>
	{
		void InitEngines();

		void InitWithPatterns(IList<HistoryPattern> setupPatterns);

		T ResolveEngine(Period period);

		T DefaultEngine();
	}
}
