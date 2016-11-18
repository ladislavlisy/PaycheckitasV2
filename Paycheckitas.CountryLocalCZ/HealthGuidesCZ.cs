using System;
using Paycheckitas.CountryService.Health;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryLocalCZ.Health
{
	public class HealthGuidesCZ : HealthGuides
	{
		public static HealthGuides Guides2016 ()
		{
			return new HealthGuidesCZ (HealthProperties2016.DEFAULT,
				HealthProperties2016.YEAR, HealthProperties2016.YEAR);
		}

		protected HealthGuidesCZ (bool defaultGuides, int validFrom, int validUpto) : 
			base(defaultGuides, validFrom, validUpto)
		{
		}

	}
}
