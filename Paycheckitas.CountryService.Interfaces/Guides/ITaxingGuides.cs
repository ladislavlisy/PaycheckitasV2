using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface ITaxingGuides
	{
		bool ValidatePeriod (Period period);
	}
}
