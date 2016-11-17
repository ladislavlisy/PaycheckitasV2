using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Health
{
	public abstract class HealthGuides : GeneralEngineGuides, IHealthGuides
	{
		protected HealthGuides (int validYear) : base (validYear)
		{

		}

		public virtual object Clone ()
		{
			HealthGuides other = (HealthGuides)this.MemberwiseClone ();
			return other;
		}
	}
}
