using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface ISocialGuides
	{
		bool ValidatePeriod (Period period);
	}
}
