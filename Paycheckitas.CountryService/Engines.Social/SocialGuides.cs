using System;
using Paycheckitas.CountryService.Interfaces;

namespace Paycheckitas.CountryService.Social
{
	public abstract class SocialGuides : GeneralEngineGuides, ISocialGuides
	{
		protected SocialGuides (int validYear) : base (validYear)
		{

		}

		public virtual object Clone ()
		{
			SocialGuides other = (SocialGuides)this.MemberwiseClone ();
			return other;
		}
	}
}
