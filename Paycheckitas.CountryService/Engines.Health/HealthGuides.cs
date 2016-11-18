using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Health
{
	public abstract class HealthGuides : GeneralEngineGuides, IHealthGuides
	{
		protected HealthGuides (bool defaultGuides, int validFrom, int validUpto) : 
			base (defaultGuides, validFrom, validUpto)
		{

		}

		public virtual object Clone ()
		{
			HealthGuides other = (HealthGuides)this.MemberwiseClone ();
			return other;
		}
	}
}
