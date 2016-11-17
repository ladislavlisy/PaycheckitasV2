using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.CountryService.Interfaces
{
	public interface ICountryProfile
	{
		Period ProfilePeriod();
		IEmployEngine Employ();
		ITaxingEngine Taxing();
		IHealthEngine Health();
		ISocialEngine Social();
	}
}
