using System;
using Paycheckitas.CountryLocalCZ.Taxing;
using Paycheckitas.CountryService.Taxing;

namespace Paycheckitas.CountryService.History.TaxingEngines
{
	public class TaxingEngine2016 : TaxingEnginePrototype
	{
		public TaxingEngine2016 () : base (TaxingGuidesCZ.Guides2016 ())
		{
		}

		#region implemented abstract members of TaxingEnginePrototype
		#endregion

	}
}
