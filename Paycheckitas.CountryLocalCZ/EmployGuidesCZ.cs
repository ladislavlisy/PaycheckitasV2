using System;
using Paycheckitas.CountryService.Employ;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryLocalCZ.Employ
{
	public class EmployGuidesCZ : EmployGuides
	{
		public static EmployGuides Guides2016()
		{
			return new EmployGuidesCZ(
				EmployProperties2016.YEAR,
				EmployProperties2016.DAYS_WORKING_WEEKLY,
				EmployProperties2016.HOURS_WORKING_DAILY);
		}

		protected EmployGuidesCZ(int validYear, Int32 weeklyWorkingDays, Int32 dailyWorkingHours) : base(validYear, weeklyWorkingDays, dailyWorkingHours)
		{
		}

	}
}
