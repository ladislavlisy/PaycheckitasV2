using System;
using Paycheckitas.Common;
using Paycheckitas.Common.Core;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Employ
{
	public abstract class EmployGuides : EngineGeneralGuides, IEmployGuides
	{
		private readonly Int32 __weeklyWorkingDays;

		private readonly Int32 __dailyWorkingHours;

		private readonly Int32 __dailyWorkingSeconds;

		private readonly Int32 __weeklyWorkingSeconds;

		protected EmployGuides(int validYear,
			Int32 weeklyWorkingDays,
			Int32 dailyWorkingHours) : base(validYear)
		{
			__weeklyWorkingDays = weeklyWorkingDays;

			__dailyWorkingHours = dailyWorkingHours;

			__dailyWorkingSeconds = PeriodOperations.WorkingSecondsDaily(__dailyWorkingHours);

			__weeklyWorkingSeconds = PeriodOperations.WorkingSecondsWeekly(__weeklyWorkingDays, __dailyWorkingHours);

		}

		public Int32 WeeklyWorkingDaysGuide()
		{
			return __weeklyWorkingDays;
		}

		public Int32 DailyWorkingHoursGuide()
		{
			return __dailyWorkingHours;
		}

		public Int32 DailyWorkingSecondsGuide()
		{
			return __dailyWorkingSeconds;
		}

		public Int32 WeeklyWorkingSecondsGuide()
		{
			return __weeklyWorkingSeconds;
		}

		public virtual object Clone()
		{
			EmployGuides other = (EmployGuides)this.MemberwiseClone();
			return other;
		}
	}
}

