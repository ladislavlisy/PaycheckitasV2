using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Taxing
{
	public abstract class TaxingEnginePrototype : ITaxingEngine
	{
		public TaxingEnginePrototype (TaxingGuides currentGuides)
		{
			EngineGuides = currentGuides.Clone () as ITaxingGuides;
		}

		private ITaxingGuides EngineGuides { get; set; }

		#region ITaxingEngine implementation
		#endregion

		public ITaxingGuides Guides ()
		{
			return EngineGuides;
		}

		#region IPeriodTaxingGuides implementation
		#endregion
	}
}
