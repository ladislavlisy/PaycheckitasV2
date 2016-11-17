using System;
using Paycheckitas.CountryService.Social;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryLocalCZ.Social
{
	public class SocialGuidesCZ : SocialGuides
	{
		public static SocialGuides Guides2016 ()
		{
			return new SocialGuidesCZ (SocialProperties2016.YEAR);
		}

		protected SocialGuidesCZ (int validYear) : base (validYear)
		{
		}

	}
}
