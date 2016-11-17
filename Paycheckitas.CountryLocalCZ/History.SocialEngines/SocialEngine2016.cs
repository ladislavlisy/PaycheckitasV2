using System;
using Paycheckitas.CountryLocalCZ.Social;
using Paycheckitas.CountryService.Social;

namespace Paycheckitas.CountryService.History.SocialEngines
{
	public class SocialEngine2016 : SocialEnginePrototype
	{
		public SocialEngine2016 () : base (SocialGuidesCZ.Guides2016 ())
		{
		}

		#region implemented abstract members of SocialEnginePrototype
		#endregion

	}
}
