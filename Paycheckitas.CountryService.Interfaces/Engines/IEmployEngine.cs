using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface IEmployEngine : IPeriodEmployGuides
	{
		IEmployGuides Guides();

		uint DayFromOrdinal(Period period, DateTime? dateFrom);

		uint DayEndsOrdinal(Period period, DateTime? dateEnds);

		Int32[] WeekWorkSchedule(Period period, Int32 secondsWeekly, Int32 workdaysWeekly);

		Int32[] MonthWorkSchedule(Period period, Int32[] weekSchedule);

		Int32[] TimesheetWorkSchedule(Period period, Int32[] monthSchedule, uint dayFrom, uint dayEnds);

		Int32[] TimesheetAbsenceSchedule(Period period, Int32[] absenceHours, uint dayFrom, uint dayEnds);

		Int32 TotalHoursForSalary(Period period, Int32 fulltimeHour, Int32 workingHours, Int32 absenceHours);

		decimal SalaryAmountFullSchedule(Period period, decimal amountMonthly);

		decimal SalaryAmountWorkingTime(Period period, decimal amountMonthly, Int32 fulltimeHour, Int32 workingHours, Int32 absenceHours);
	}
}