using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService
{
	public class GeneralEngineGuides
	{
		public GeneralEngineGuides(int year)
		{
			ValidFrom = new Period(year, 1);
			ValidUpto = new Period(year, 12);
		}

		public Period ValidFrom { get; private set; }

		public Period ValidUpto { get; private set; }

		public bool ValidatePeriod(Period period)
		{
			return (period >= ValidFrom && period <= ValidUpto);
		}
	}
}
