using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface IPeriodEmployGuides
	{
		Int32 WeeklyWorkingDays(Period period);

		Int32 DailyWorkingHours(Period period);

		Int32 DailyWorkingSeconds(Period period);

		Int32 WeeklyWorkingSeconds(Period period);
	}
}