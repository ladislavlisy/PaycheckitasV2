using System;
using System.Globalization;

namespace Paycheckitas.Common.Core
{
	public class Period : IComparable
	{
		public int Month { get; private set; }
		public int Year { get; private set; }

		public Period(int year, int month)
		{
			this.Year = year;
			this.Month = month;
		}

		public Period() : this(0, 0)
		{
		}

		public Period(UInt32 periodCode) : this((int)(periodCode / 100), (int)(periodCode % 100))
		{
		}

		public bool IsNull()
		{
			return (this.Month == 0 || this.Year == 0);
		}

		public int PeriodCode()
		{
			if (IsNull())
			{
				return 0;
			}
			return this.Year * 100 + this.Month;
		}

		public string Description()
		{
			var firstPeriodDay = new DateTime(Year, Month, 1);
			return firstPeriodDay.ToString("MMMM yyyy");
		}

		public string DescriptionEn()
		{
			CultureInfo enCultureInfo = new CultureInfo("en-US");
			DateTime firstPeriodDay = new DateTime(Year, Month, 1);
			return firstPeriodDay.ToString("MMMM yyyy", enCultureInfo);
		}

		public static bool operator <(Period x, Period y)
		{
			return (x.PeriodCode() < y.PeriodCode());
		}

		public static bool operator >(Period x, Period y)
		{
			return (x.PeriodCode() > y.PeriodCode());
		}

		public static bool operator <=(Period x, Period y)
		{
			return (x.PeriodCode() <= y.PeriodCode());
		}

		public static bool operator >=(Period x, Period y)
		{
			return (x.PeriodCode() >= y.PeriodCode());
		}

		public int CompareTo(object obj)
		{
			Period other = obj as Period;

			return this.PeriodCode().CompareTo(other.PeriodCode());
		}

		public bool EqualsToPeriod(Period other)
		{
			return (this.PeriodCode() == other.PeriodCode());
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
				return true;
			if (obj == null || this.GetType() != obj.GetType())
				return false;

			Period other = obj as Period;

			return this.EqualsToPeriod(other);
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;

			result += prime * result + (int)this.PeriodCode();

			return result;
		}

		public override string ToString()
		{
			return this.PeriodCode().ToString();
		}

		public virtual object Clone()
		{
			Period otherPeriod = (Period)this.MemberwiseClone();
			return otherPeriod;
		}
	}
}
