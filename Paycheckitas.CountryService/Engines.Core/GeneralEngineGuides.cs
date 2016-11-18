using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService
{
	public class GeneralEngineGuides
	{
		private bool DefaultGuides { get; set; }

		public GeneralEngineGuides(bool defaultGuides, int yearFrom, int yearUpto)
		{
			DefaultGuides = defaultGuides;

			ValidFrom = new Period(yearFrom, 1);

			ValidUpto = new Period(yearUpto, 12);
		}

		public bool IsDefault ()
		{
			return DefaultGuides;
		}

		public UInt16 YearFrom ()
		{
			return (UInt16)ValidFrom.Year;
		}

		public UInt16 YearUpto ()
		{
			return (UInt16)ValidUpto.Year;
		}

		public Period ValidFrom { get; private set; }

		public Period ValidUpto { get; private set; }

		public bool ValidatePeriod(Period period)
		{
			return (period >= ValidFrom && period <= ValidUpto);
		}
	}
}
