using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface ISocialGuides
	{
		bool IsDefault ();

		UInt16 YearFrom ();

		UInt16 YearUpto ();

		bool ValidatePeriod (Period period);
	}
}
