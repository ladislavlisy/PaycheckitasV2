using System;
using Paycheckitas.CountryService.Taxing;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryLocalCZ.Taxing
{
	public class TaxingGuidesCZ : TaxingGuides
	{
		public static TaxingGuides Guides2016 ()
		{
			return new TaxingGuidesCZ (TaxingProperties2016.YEAR);
		}

		protected TaxingGuidesCZ (int validYear) : base (validYear)
		{
		}

	}
}
