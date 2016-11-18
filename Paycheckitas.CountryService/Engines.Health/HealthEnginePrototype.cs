using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Health
{
	public abstract class HealthEnginePrototype : IHealthEngine
	{
		public HealthEnginePrototype (HealthGuides currentGuides)
		{
			EngineGuides = currentGuides.Clone () as IHealthGuides;

			EnginePattern = HistoryPattern.Years (EngineGuides.YearFrom (), EngineGuides.YearUpto (), EngineGuides.IsDefault ());
		}

		private IHealthGuides EngineGuides { get; set; }

		private HistoryPattern EnginePattern { get; set; }

		#region IHealthEngine implementation

		public HistoryPattern Pattern ()
		{
			return EnginePattern;
		}

		public IHealthGuides Guides ()
		{
			return EngineGuides;
		}

		#endregion

		#region IPeriodHealthGuides implementation
		#endregion
	}
}
