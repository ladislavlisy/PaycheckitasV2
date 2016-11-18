using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Taxing
{
	public abstract class TaxingGuides : GeneralEngineGuides, ITaxingGuides
	{
		protected TaxingGuides (bool defaultGuides, int validFrom, int validUpto) : 
			base (defaultGuides, validFrom, validUpto)
		{

		}

		public virtual object Clone ()
		{
			TaxingGuides other = (TaxingGuides)this.MemberwiseClone ();
			return other;
		}
	}
}
