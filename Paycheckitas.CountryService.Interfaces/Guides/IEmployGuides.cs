﻿using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface IEmployGuides
	{
		bool IsDefault ();

		UInt16 YearFrom ();

		UInt16 YearUpto ();

		bool ValidatePeriod(Period period);

		Int32 WeeklyWorkingDaysGuide();

		Int32 DailyWorkingHoursGuide();

		Int32 DailyWorkingSecondsGuide();

		Int32 WeeklyWorkingSecondsGuide();
	}
}