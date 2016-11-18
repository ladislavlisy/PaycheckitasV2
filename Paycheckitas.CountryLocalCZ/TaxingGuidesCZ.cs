using System;
using Paycheckitas.CountryService.Taxing;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryLocalCZ.Taxing
{
	public class TaxingGuidesCZ : TaxingGuides
	{
		public static TaxingGuides Guides2016 ()
		{
			return new TaxingGuidesCZ (TaxingProperties2016.DEFAULT,
				TaxingProperties2016.YEAR, TaxingProperties2016.YEAR);
		}

		protected TaxingGuidesCZ (bool defaultGuides, int validFrom, int validUpto) : 
			base (defaultGuides, validFrom, validUpto)
		{
		}

	}
}
