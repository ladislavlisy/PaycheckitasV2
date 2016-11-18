using System;
using Paycheckitas.CountryService.Social;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryLocalCZ.Social
{
	public class SocialGuidesCZ : SocialGuides
	{
		public static SocialGuides Guides2016 ()
		{
			return new SocialGuidesCZ (SocialProperties2016.DEFAULT,
				SocialProperties2016.YEAR, SocialProperties2016.YEAR);
		}

		protected SocialGuidesCZ (bool defaultGuides, int validFrom, int validUpto) : 
			base (defaultGuides, validFrom, validUpto)
		{
		}

	}
}
