using System;
using Paycheckitas.Common.Core;
using Paycheckitas.CountryService;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryLocalCZ
{
	public class CountryServiceModule : ICountryService
	{
		public static ICountryService CreateModule()
		{
			ICountryService module = new CountryServiceModule();

			return module;
		}

		private CountryServiceModule()
		{
			HistoryOfEmploy = EmployEnginesHistory.CreateEngines();

			HistoryOfTaxing = TaxingEnginesHistory.CreateEngines();

			HistoryOfHealth = HealthEnginesHistory.CreateEngines();

			HistoryOfSocial = SocialEnginesHistory.CreateEngines();
		}

		public ICountryProfile BuildCountryProfile(Period period)
		{
			IEmployEngine periodEngine = HistoryOfEmploy.ResolveEngine(period);
			ITaxingEngine taxingEngine = HistoryOfTaxing.ResolveEngine(period);
			IHealthEngine healthEngine = HistoryOfHealth.ResolveEngine(period);
			ISocialEngine socialEngine = HistoryOfSocial.ResolveEngine(period);

			return new CountryProfile(period, periodEngine, taxingEngine, healthEngine, socialEngine);
		}

		private IEnginesHistory<IEmployEngine> HistoryOfEmploy { get; set; }

		private IEnginesHistory<ITaxingEngine> HistoryOfTaxing { get; set; }

		private IEnginesHistory<IHealthEngine> HistoryOfHealth { get; set; }

		private IEnginesHistory<ISocialEngine> HistoryOfSocial { get; set; }

	}
}
