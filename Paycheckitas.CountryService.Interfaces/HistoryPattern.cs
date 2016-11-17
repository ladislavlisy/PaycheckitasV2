using System;
using System.Text;

namespace Paycheckitas.CountryService.Interfaces
{
	public class HistoryPattern : IComparable
	{
		public static HistoryPattern Year(UInt16 year)
		{
			return new HistoryPattern(year, year);
		}

		public static HistoryPattern Years(UInt16 from, UInt16 upto)
		{
			return new HistoryPattern(from, upto);
		}

		public UInt16 YearFrom { get; private set; }
		public UInt16 YearUpto { get; private set; }

		public HistoryPattern(UInt16 from, UInt16 upto)
		{
			this.YearFrom = from;
			this.YearUpto = upto;
		}

		public HistoryPattern() : this(0, 0)
		{
		}
		public static bool operator <(HistoryPattern x, HistoryPattern y)
		{
			return (x.YearFrom < y.YearFrom) || (x.YearFrom == y.YearFrom && (x.YearUpto < y.YearUpto));
		}

		public static bool operator >(HistoryPattern x, HistoryPattern y)
		{
			return (x.YearFrom > y.YearFrom) || (x.YearFrom == y.YearFrom && (x.YearUpto > y.YearUpto));
		}

		public static bool operator <=(HistoryPattern x, HistoryPattern y)
		{
			return (x.YearFrom <= y.YearFrom) || (x.YearFrom == y.YearFrom && (x.YearUpto <= y.YearUpto));
		}

		public static bool operator >=(HistoryPattern x, HistoryPattern y)
		{
			return (x.YearFrom >= y.YearFrom) || (x.YearFrom == y.YearFrom && (x.YearUpto >= y.YearUpto));
		}

		public int CompareTo(object obj)
		{
			HistoryPattern other = obj as HistoryPattern;

			if (this.YearFrom != other.YearFrom)
			{
				return this.YearFrom.CompareTo(other.YearFrom);
			}
			return (this.YearUpto.CompareTo(other.YearUpto));
		}

		public bool EqualsToHistoryPattern(HistoryPattern other)
		{
			return (this.YearFrom == other.YearFrom && this.YearUpto == other.YearUpto);
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
				return true;
			if (obj == null || this.GetType() != obj.GetType())
				return false;

			HistoryPattern other = obj as HistoryPattern;

			return this.EqualsToHistoryPattern(other);
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;

			result += prime * result + (int)this.YearFrom;
			result += prime * result + (int)this.YearUpto;

			return result;
		}

		public string ClassName()
		{
			StringBuilder classNameBuilder = new StringBuilder(YearFrom.ToString());

			if (YearFrom != YearUpto)
			{
				classNameBuilder.Append("to").Append(YearUpto.ToString());
			}
			return classNameBuilder.ToString();
		}
	}
}
