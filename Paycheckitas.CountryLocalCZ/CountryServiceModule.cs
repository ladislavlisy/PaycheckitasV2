using System;
using System.Reflection;
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
			Assembly serviceModuleAssembly = this.GetType().Assembly;

			HistoryOfEmploy = EmployEnginesHistory.CreateEngines(serviceModuleAssembly);

			HistoryOfTaxing = TaxingEnginesHistory.CreateEngines(serviceModuleAssembly);

			HistoryOfHealth = HealthEnginesHistory.CreateEngines(serviceModuleAssembly);

			HistoryOfSocial = SocialEnginesHistory.CreateEngines(serviceModuleAssembly);
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
