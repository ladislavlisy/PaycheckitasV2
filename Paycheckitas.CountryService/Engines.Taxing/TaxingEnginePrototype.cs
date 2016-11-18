using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Taxing
{
	public abstract class TaxingEnginePrototype : ITaxingEngine
	{
		public TaxingEnginePrototype (TaxingGuides currentGuides)
		{
			EngineGuides = currentGuides.Clone () as ITaxingGuides;

			EnginePattern = HistoryPattern.Years (EngineGuides.YearFrom (), EngineGuides.YearUpto (), EngineGuides.IsDefault ());
		}

		private ITaxingGuides EngineGuides { get; set; }

		private HistoryPattern EnginePattern { get; set; }

		#region ITaxingEngine implementation

		public HistoryPattern Pattern ()
		{
			return EnginePattern;
		}

		public ITaxingGuides Guides ()
		{
			return EngineGuides;
		}

		#endregion

		#region IPeriodTaxingGuides implementation
		#endregion
	}
}
