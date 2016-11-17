using System;
namespace Paycheckitas.Common
{
	public static class PayRounding
	{
		public static decimal MonthlyAmountWithWorkingHours(decimal amountMonthly, decimal scheduleFactor, int timesheetHours, int workingHours, int absenceHours)
		{
			decimal amountFactor = FactorizeAmount(amountMonthly, scheduleFactor);

			decimal paymentValue = PaymentFromAmount(amountFactor, timesheetHours, workingHours, absenceHours);
			return paymentValue;
		}

		public static Int32 TotalHoursForPayment(Int32 timesheetHours, Int32 workingHours, Int32 absenceHours)
		{
			Int32 totalsHours = Math.Max(0, workingHours - absenceHours);

			Int32 resultHours = Math.Min(timesheetHours, totalsHours);

			return resultHours;
		}

		public static decimal FactorizeAmount(decimal amount, decimal factor)
		{
			decimal result = DecOperations.Multiply(amount, factor);

			return result;
		}

		public static decimal PaymentFromAmount(decimal amountMonthly, Int32 timesheetHours, Int32 workingHours, Int32 absenceHours)
		{
			Int32 totalHours = TotalHoursForPayment(timesheetHours, workingHours, absenceHours);

			decimal payment = DecOperations.MultiplyAndDivide(amountMonthly, totalHours, timesheetHours);

			return payment;
		}
	}
}
 