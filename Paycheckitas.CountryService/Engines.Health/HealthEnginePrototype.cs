using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Health
{
	public abstract class HealthEnginePrototype : IHealthEngine
	{
		public HealthEnginePrototype (HealthGuides currentGuides)
		{
			EngineGuides = currentGuides.Clone () as IHealthGuides;
		}

		private IHealthGuides EngineGuides { get; set; }

		#region IHealthEngine implementation
		#endregion

		public IHealthGuides Guides ()
		{
			return EngineGuides;
		}

		#region IPeriodHealthGuides implementation
		#endregion
	}
}
