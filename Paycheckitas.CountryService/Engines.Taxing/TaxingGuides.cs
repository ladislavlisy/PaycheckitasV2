using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Taxing
{
	public abstract class TaxingGuides : GeneralEngineGuides, ITaxingGuides
	{
		protected TaxingGuides (int validYear) : base (validYear)
		{

		}

		public virtual object Clone ()
		{
			TaxingGuides other = (TaxingGuides)this.MemberwiseClone ();
			return other;
		}
	}
}
