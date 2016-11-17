using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Social
{
	public abstract class SocialEnginePrototype : ISocialEngine
	{
		public SocialEnginePrototype (SocialGuides currentGuides)
		{
			EngineGuides = currentGuides.Clone () as ISocialGuides;
		}

		private ISocialGuides EngineGuides { get; set; }

		#region ISocialEngine implementation
		#endregion

		public ISocialGuides Guides ()
		{
			return EngineGuides;
		}

		#region IPeriodSocialGuides implementation
		#endregion
	}
}
