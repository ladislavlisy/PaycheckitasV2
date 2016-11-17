using System;
using Paycheckitas.CountryLocalCZ.Health;
using Paycheckitas.CountryService.Health;

namespace Paycheckitas.CountryService.History.HealthEngines
{
	public class HealthEngine2016 : HealthEnginePrototype
	{
		public HealthEngine2016 () : base (HealthGuidesCZ.Guides2016 ())
		{
		}

		#region implemented abstract members of HealthEnginePrototype
		#endregion

	}
}
