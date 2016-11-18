using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Social
{
	public abstract class SocialEnginePrototype : ISocialEngine
	{
		public SocialEnginePrototype (SocialGuides currentGuides)
		{
			EngineGuides = currentGuides.Clone () as ISocialGuides;

			EnginePattern = HistoryPattern.Years (EngineGuides.YearFrom (), EngineGuides.YearUpto (), EngineGuides.IsDefault ());
		}

		private ISocialGuides EngineGuides { get; set; }

		private HistoryPattern EnginePattern { get; set; }

		#region ISocialEngine implementation

		public HistoryPattern Pattern ()
		{
			return EnginePattern;
		}

		public ISocialGuides Guides ()
		{
			return EngineGuides;
		}

		#endregion

		#region IPeriodSocialGuides implementation
		#endregion
	}
}
