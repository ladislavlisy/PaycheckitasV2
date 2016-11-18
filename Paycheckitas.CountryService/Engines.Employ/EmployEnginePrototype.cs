using System;
using Paycheckitas.Common;
using Paycheckitas.Common.Core;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Employ
{
	public class EmployEnginePrototype : IEmployEngine
	{
		public EmployEnginePrototype(EmployGuides currentGuides)
		{
			EngineGuides = currentGuides.Clone () as IEmployGuides;

			EnginePattern = HistoryPattern.Years(EngineGuides.YearFrom(), EngineGuides.YearUpto (), EngineGuides.IsDefault ());
		}

		private IEmployGuides EngineGuides { get; set; }

		private HistoryPattern EnginePattern { get; set; }

		#region IEmployEngine implementation

		public HistoryPattern Pattern ()
		{
			return EnginePattern;
		}

		public IEmployGuides Guides()
		{
			return EngineGuides;
		}

		public uint DayFromOrdinal(Period period, DateTime? dateFrom)
		{
			return PeriodOperations.DateFromInPeriod(period, dateFrom);
		}

		public uint DayEndsOrdinal(Period period, DateTime? dateEnds)
		{
			return PeriodOperations.DateEndsInPeriod(period, dateEnds);
		}

		public Int32[] WeekWorkSchedule(Period period, Int32 secondsWeekly, Int32 workdaysWeekly)
		{
			return PeriodOperations.WeekSchedule(period, secondsWeekly, workdaysWeekly);
		}

		public Int32[] MonthWorkSchedule(Period period, Int32[] weekSchedule)
		{
			return PeriodOperations.MonthSchedule(period, weekSchedule);
		}

		public Int32[] TimesheetWorkSchedule(Period period, Int32[] monthSchedule, uint dayFrom, uint dayEnds)
		{
			return PeriodOperations.TimesheetSchedule(period, monthSchedule, dayFrom, dayEnds);
		}

		public Int32[] TimesheetAbsenceSchedule(Period period, Int32[] absenceHours, uint dayFrom, uint dayEnds)
		{
			return PeriodOperations.TimesheetAbsence(period, absenceHours, dayFrom, dayEnds);
		}

		public Int32 TotalHoursForSalary(Period period, Int32 fulltimeHour, Int32 workingHours, Int32 absenceHours)
		{
			return PayRounding.TotalHoursForPayment(fulltimeHour, workingHours, absenceHours);
		}

		public decimal SalaryAmountFullSchedule(Period period, decimal amountMonthly)
		{
			return PayRounding.FactorizeAmount(amountMonthly, 1m);
		}

		public decimal SalaryAmountWorkingTime(Period period, decimal amountMonthly, Int32 fulltimeHour, Int32 workingHours, Int32 absenceHours)
		{
			return PayRounding.MonthlyAmountWithWorkingHours(amountMonthly, 1m, fulltimeHour, workingHours, absenceHours);
		}

		#endregion

		#region IPeriodEmployGuides implementation

		public int WeeklyWorkingDays(Period period)
		{
			return EngineGuides.WeeklyWorkingDaysGuide();
		}

		public int DailyWorkingHours(Period period)
		{
			return EngineGuides.DailyWorkingHoursGuide();
		}

		public int DailyWorkingSeconds(Period period)
		{
			return EngineGuides.DailyWorkingSecondsGuide();
		}

		public int WeeklyWorkingSeconds(Period period)
		{
			return EngineGuides.WeeklyWorkingSecondsGuide();
		}

		#endregion
	}
}
