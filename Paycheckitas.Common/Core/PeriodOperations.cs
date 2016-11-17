using System;
using System.Linq;

namespace Paycheckitas.Common.Core
{
	public class PeriodOperations
	{
		public const uint TERM_BEG_FINISHED = 32;

		public const uint TERM_END_FINISHED = 0;

		public const int WEEKSUN_SUNDAY = 0;

		public const int WEEKMON_SUNDAY = 7;

		public const Int32 TIME_MULTIPLY_SIXTY = 60;

		public static int DayOfWeekMonToSun(int periodDateCwd)
		{
			// DayOfWeek Sunday = 0,
			// Monday = 1, Tuesday = 2, Wednesday = 3, Thursday = 4, Friday = 5, Saturday = 6, 
			if (periodDateCwd == WEEKSUN_SUNDAY)
			{
				return WEEKMON_SUNDAY;
			}
			else {
				return periodDateCwd;
			}
		}

		public static int DaysInMonth(Period period)
		{
			return DateTime.DaysInMonth(period.Year, period.Month);
		}

		public static Period Empty()
		{
			return new Period(0, 0);
		}

		public static Period BeginYear(int year)
		{
			return new Period(year, 1);
		}

		public static Period EndYear(int year)
		{
			return new Period(year, 12);
		}
		public static DateTime BeginOfMonth(Period period)
		{
			return new DateTime(period.Year, period.Month, 1);
		}

		public static DateTime EndOfMonth(Period period)
		{
			return new DateTime(period.Year, period.Month, DaysInMonth(period));
		}

		public static DateTime DateOfMonth(Period period, int dayOrdinal)
		{
			int periodDay = Math.Min(Math.Max(1, dayOrdinal), DaysInMonth(period));

			return new DateTime(period.Year, period.Month, periodDay);
		}

		public static int WeekDayOfMonth(Period period, int dayOrdinal)
		{
			DateTime periodDate = DateOfMonth(period, dayOrdinal);

			int periodDateCwd = (int)periodDate.DayOfWeek;

			return DayOfWeekMonToSun(periodDateCwd);
		}
		public static int WorkingSecondsDaily(int workingHours)
		{
			Int32 secondsInHour = (TIME_MULTIPLY_SIXTY * TIME_MULTIPLY_SIXTY);

			return (workingHours * secondsInHour);
		}

		public static int WorkingSecondsWeekly(int workingDays, int workingHours)
		{
			Int32 secondsDaily = WorkingSecondsDaily(workingHours);

			return (workingDays * secondsDaily);
		}

		public static uint DateFromInPeriod(Period period, DateTime? dateFrom)
		{
			uint dayTermFrom = TERM_BEG_FINISHED;

			DateTime periodDateBeg = new DateTime(period.Year, period.Month, 1);

			if (dateFrom != null)
			{
				dayTermFrom = (uint)dateFrom.Value.Day;
			}

			if (dateFrom == null || dateFrom < periodDateBeg)
			{
				dayTermFrom = 1;
			}
			return dayTermFrom;
		}

		public static uint DateEndsInPeriod(Period period, DateTime? dateEnds)
		{
			uint dayTermEnd = TERM_END_FINISHED;
			uint daysPeriod = (uint)DateTime.DaysInMonth(period.Year, period.Month);

			DateTime periodDateEnd = new DateTime(period.Year, period.Month, (int)daysPeriod);

			if (dateEnds != null)
			{
				dayTermEnd = (uint)dateEnds.Value.Day;
			}

			if (dateEnds == null || dateEnds > periodDateEnd)
			{
				dayTermEnd = daysPeriod;
			}
			return dayTermEnd;
		}

		public static Int32[] WeekSchedule(Period period, Int32 secondsWeekly, Int32 workdaysWeekly)
		{
			Int32 secondsDaily = (secondsWeekly / Math.Min(workdaysWeekly, 7));

			Int32 secRemainder = secondsWeekly - (secondsDaily * workdaysWeekly);

			Int32[] weekSchedule = Enumerable.Range(1, 7).
				Select((x) => (WeekDaySeconds(x, workdaysWeekly, secondsDaily, secRemainder))).ToArray();

			return weekSchedule;
		}

		private static Int32 WeekDaySeconds(int dayOrdinal, int daysOfWork, Int32 secondsDaily, Int32 secRemainder)
		{
			if (dayOrdinal < daysOfWork)
			{
				return secondsDaily;
			}
			else if (dayOrdinal == daysOfWork)
			{
				return secondsDaily + secRemainder;
			}
			return (0);
		}

		public static Int32[] MonthSchedule(Period period, Int32[] weekSchedule)
		{
			int periodDaysCount = DaysInMonth(period);

			int periodBeginCwd = WeekDayOfMonth(period, 1);

			Int32[] monthSchedule = Enumerable.Range(1, periodDaysCount).
				Select((x) => (SecondsFromWeekSchedule(period, weekSchedule, x, periodBeginCwd))).ToArray();

			return monthSchedule;
		}

		private static Int32 SecondsFromWeekSchedule(Period period, Int32[] weekSchedule, int dayOrdinal, int periodBeginCwd)
		{
			int dayOfWeek = DayOfWeekFromOrdinal(dayOrdinal, periodBeginCwd);

			int indexWeek = (dayOfWeek - 1);

			if (indexWeek < 0 || indexWeek >= weekSchedule.Length)
			{
				return 0;
			}
			return weekSchedule[indexWeek];
		}

		private static Int32 SecondsFromScheduleSeq(Period period, Int32[] timeTable, int dayOrdinal, uint dayFromOrd, uint dayEndsOrd)
		{
			if (dayOrdinal < dayFromOrd || dayOrdinal > dayEndsOrd)
			{
				return 0;
			}

			int indexTable = (dayOrdinal - (Int32)dayFromOrd);

			if (indexTable < 0 || indexTable >= timeTable.Length)
			{
				return 0;
			}

			return timeTable[indexTable];
		}

		private static int DayOfWeekFromOrdinal(int dayOrdinal, int periodBeginCwd)
		{
			// dayOrdinal 1..31
			// periodBeginCwd 1..7
			// dayOfWeek 1..7

			int dayOfWeek = (((dayOrdinal - 1) + (periodBeginCwd - 1)) % 7) + 1;

			return dayOfWeek;
		}

		public static Int32[] TimesheetSchedule(Period period, Int32[] monthSchedule, uint dayOrdFrom, uint dayOrdEnds)
		{
			Int32[] timeSheet = monthSchedule.Select((x, i) => (HoursFromCalendar(dayOrdFrom, dayOrdEnds, i, x))).ToArray();

			return timeSheet;
		}

		public static Int32[] TimesheetAbsence(Period period, Int32[] absenceSchedule, uint dayOrdFrom, uint dayOrdEnds)
		{
			int periodDaysCount = DaysInMonth(period);

			Int32[] monthSchedule = Enumerable.Range(1, periodDaysCount).
				Select((x) => (SecondsFromScheduleSeq(period, absenceSchedule, x, dayOrdFrom, dayOrdEnds))).ToArray();

			return monthSchedule;
		}

		private static int HoursFromCalendar(uint dayOrdFrom, uint dayOrdEnds, int dayIndex, Int32 workSeconds)
		{
			int dayOrdinal = dayIndex + 1;

			int workingDay = workSeconds;

			if (dayOrdFrom > dayOrdinal)
			{
				workingDay = 0;
			}
			if (dayOrdEnds < dayOrdinal)
			{
				workingDay = 0;
			}
			return workingDay;
		}

		public static Int32 TotalTimesheetHours(Int32[] monthTimesheet)
		{
			if (monthTimesheet == null)
			{
				return 0;
			}
			Int32 timesheetHours = monthTimesheet.Aggregate(0, (agr, dh) => (agr + dh));

			return timesheetHours;
		}

	}
}
