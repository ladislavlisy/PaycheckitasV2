using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface IHealthGuides
	{
		bool ValidatePeriod (Period period);
	}
}
